using Abc.Data;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.Movie;

public static class MoneyApi
{
    public static IEndpointRouteBuilder MapMoneyApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<Money, IMoneyRepo>("/api/money");
}
