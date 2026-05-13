using Abc.Data;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.Movie;

public static class CountriesApi
{
    public static IEndpointRouteBuilder MapCountriesApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<Country, ICountriesRepo>("/api/countries");
}