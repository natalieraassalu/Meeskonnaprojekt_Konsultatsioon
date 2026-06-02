using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp.API;

public static class UsersApi
{
    public static IEndpointRouteBuilder MapUsersApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<User, IUsersRepo>("/api/users");
}
