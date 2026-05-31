using Abc.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Abc.Infra;

public class EfBaseRepo<TContext, TEntity>(TContext c) : IRepo<TEntity>
    where TContext : DbContext
    where TEntity : BaseEntity {
    protected readonly TContext db = c;
    protected virtual IQueryable<TEntity> Query() => db.Set<TEntity>();
    public async Task<int> CountAsync(Query q)
    {
        var r = addSearch(Query(), q);
        return await r.CountAsync();
    }
    public async Task<TEntity> CreateAsync(TEntity e) {
        await db.AddAsync(e);
        await db.SaveChangesAsync();
        return e;
    }
    public Task DeleteAsync(Guid id) => deleteAsync(id);
    public async Task<TEntity> GetAsync(Guid id) =>
        await Query().FirstOrDefaultAsync(x => x.Id == id);
    public async Task<IEnumerable<TEntity>> GetAsync(Query q) => await getAsync(q);
    public async Task<TEntity> UpdateAsync(TEntity e) {
        db.Update(e);
        await db.SaveChangesAsync();
        return e;
    }
    private async Task deleteAsync(Guid id) {
        var entity = await GetAsync(id);
        if (entity is null) return;
        await DeleteDependents(entity);
        db.Remove(entity);
        await db.SaveChangesAsync();
    }
    // Hook for repos to remove dependent rows before the entity itself is deleted.
    // Consultation FKs use DeleteBehavior.NoAction (the DB does not cascade), so a
    // parent that still has children must clear them here, otherwise SaveChanges fails
    // with a REFERENCE constraint conflict. Default is a no-op: entities whose FKs
    // cascade at the database level (e.g. Movie) need nothing here. Children are marked
    // for deletion on the same context, so the SaveChangesAsync below persists the
    // child and parent deletes together in one transaction.
    protected virtual Task DeleteDependents(TEntity entity) => Task.CompletedTask;
    private async Task<IEnumerable<TEntity>> getAsync(Query q) {
        var r = addSearch(Query(), q);
        r = addSort(r, q);
        r = addPagging(r, q);
        return await r.AsNoTracking().ToListAsync();
    }
    private static IQueryable<TEntity> addSearch(IQueryable<TEntity> r, Query q) {
        var key = searchBy(q.SearchBy, q.SearchStr);
        if (key is null) return r;
        return r.Where(key); 
    }
    private static IQueryable<TEntity> addSort(IQueryable<TEntity> r, Query q) {
        var dir = q.SortDir;
        var key = sortBy(q.SortBy);
        if (key is null) return r;
        return (dir == "desc") ? r.OrderByDescending(key) : r.OrderBy(key);
    }
    private static IQueryable<TEntity> addPagging(IQueryable<TEntity> r, Query q) {
        var s = (q.Page - 1) * q.PageSize;
        var t = q.PageSize;
        return r.Skip(s).Take(t);
    }
    private static readonly BindingFlags flags
        = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;
    private static PropertyInfo getProp(string propName)
        => string.IsNullOrEmpty(propName) ? null : typeof(TEntity).GetProperty(propName, flags);
    private static Expression<Func<TEntity, object>> sortBy(string propName) {
        var p = getProp(propName);
        if (p is null) return null;
        if (string.IsNullOrEmpty(propName)) return null;
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var member = Expression.Property(parameter, p);
        var converted = Expression.Convert(member, typeof(object));
        return Expression.Lambda<Func<TEntity, object>>(converted, parameter);
    }
    private static Expression<Func<TEntity, bool>> searchBy(string searchBy, string searchStr) {
        var p = getProp(searchBy);
        if (p?.PropertyType != typeof(string)) return null;
        if (string.IsNullOrEmpty(searchStr)) return null;
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var member = Expression.Property(parameter, p);
        var notNull = Expression.NotEqual(member, Expression.Constant(null, typeof(string)));
        var contains = Expression.Call(member, nameof(string.Contains), Type.EmptyTypes, Expression.Constant(searchStr));
        var body = Expression.AndAlso(notNull, contains);
        return Expression.Lambda<Func<TEntity, bool>>(body, parameter);
    }
}
