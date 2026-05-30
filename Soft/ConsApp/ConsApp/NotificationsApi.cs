using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp;

public static class NotificationsApi
{
    public static IEndpointRouteBuilder MapNotificationsApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<Notification, INotificationsRepo>("/api/notifications");
}
