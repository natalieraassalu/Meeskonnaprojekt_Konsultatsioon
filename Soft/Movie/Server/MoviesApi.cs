using Abc.Data;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.Movie;

public static class MoviesApi
{
    public static IEndpointRouteBuilder MapMoviesApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<Data.Movie, IMoviesRepo>("/api/movies");
}