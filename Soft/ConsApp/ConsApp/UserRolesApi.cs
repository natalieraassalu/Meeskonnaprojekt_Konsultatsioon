using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp;

public static class UserRolesApi
{
    public static IEndpointRouteBuilder MapUserRolesApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<UserRole, IUserRolesRepo>("/api/userroles");
}
