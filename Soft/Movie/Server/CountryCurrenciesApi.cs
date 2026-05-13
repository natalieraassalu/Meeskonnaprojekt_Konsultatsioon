using Abc.Data;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.Movie;

public static class CountryCurrenciesApi
{
    public static IEndpointRouteBuilder MapCountryCurrenciesApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<CountryCurrency, ICountryCurrenciesRepo>("/api/countrycurrencies");
}
