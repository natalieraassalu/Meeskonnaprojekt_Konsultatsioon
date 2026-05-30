using Abc.Data.Common;
using Abc.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp;

public static class CrudApi
{
    public static IEndpointRouteBuilder MapCrudApi<TEntity, TRepo>(this IEndpointRouteBuilder app, string path)
        where TEntity : BaseEntity
        where TRepo : class, IRepo<TEntity>
    {
        var g = app.MapGroup(path);
        g.MapGet("/", async (HttpContext context, TRepo repo) => {
            var q = toQuery(context);
            return Results.Ok(await repo.GetAsync(q));
        });
        g.MapGet("/count", async (HttpContext context, TRepo repo) => {
            var q = toQuery(context);
            return Results.Ok(await repo.CountAsync(q));
        });
        g.MapGet("/{id:guid}", async (Guid id, TRepo repo) => {
            var e = await repo.GetAsync(id);
            return e is null ? Results.NotFound() : Results.Ok(e);
        });
        g.MapPost("/", async (TEntity e, TRepo repo) => Results.Ok(await repo.CreateAsync(e)));
        g.MapPut("/{id:guid}", async (Guid id, TEntity e, TRepo repo) => {
            e.Id = id;
            return Results.Ok(await repo.UpdateAsync(e));
        });
        g.MapDelete("/{id:guid}", async (Guid id, TRepo repo) => {
            await repo.DeleteAsync(id);
            return Results.NoContent();
        });
        return app;
    }

    private static Query toQuery(HttpContext context)
        => new(context.Request.Query.ToDictionary(x => x.Key, x => x.Value.ToString()));
}
