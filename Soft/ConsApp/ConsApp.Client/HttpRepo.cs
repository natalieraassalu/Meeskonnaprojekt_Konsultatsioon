using Abc.Data.Common;
using Abc.Infra;
using System.Net.Http.Json;

namespace Abc.Soft.ConsApp.Client;

public abstract class HttpRepo<TEntity>(HttpClient http, string path) : IRepo<TEntity>
    where TEntity : BaseEntity
{
    public async Task<TEntity> GetAsync(Guid id)
    {
        var r = await http.GetAsync($"/{path}/{id}");
        if (!r.IsSuccessStatusCode) return null;
        return await r.Content.ReadFromJsonAsync<TEntity>();
    }
    public async Task<int> CountAsync(Query q)
    {
        var r = await http.GetAsync(q.Href($"/{path}/count"));
        if (!r.IsSuccessStatusCode) return 0;
        return await r.Content.ReadFromJsonAsync<int>();
    }
    public async Task<IEnumerable<TEntity>> GetAsync(Query q)
    {
        var r = await http.GetAsync(q.Href($"/{path}"));
        if (!r.IsSuccessStatusCode) return [];
        return await r.Content.ReadFromJsonAsync<List<TEntity>>() ?? [];
    }
    public async Task<TEntity> CreateAsync(TEntity e)
    {
        var r = await http.PostAsJsonAsync($"/{path}/", e);
        if (!r.IsSuccessStatusCode) return null;
        return await r.Content.ReadFromJsonAsync<TEntity>();
    }
    public async Task<TEntity> UpdateAsync(TEntity e)
    {
        var r = await http.PutAsJsonAsync($"/{path}/{e.Id}", e);
        if (!r.IsSuccessStatusCode) return null;
        return await r.Content.ReadFromJsonAsync<TEntity>();
    }
    public async Task DeleteAsync(Guid id)
        => await http.DeleteAsync($"/{path}/{id}");
}
