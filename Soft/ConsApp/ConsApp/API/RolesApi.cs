using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp.API;

public static class RolesApi
{
    public static IEndpointRouteBuilder MapRolesApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<Role, IRolesRepo>("/api/roles");
}
