using Abc.Data;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.Movie;

public static class CurrenciesApi
{
    public static IEndpointRouteBuilder MapCurrenciesApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<Currency, ICurrenciesRepo>("/api/currencies");
}