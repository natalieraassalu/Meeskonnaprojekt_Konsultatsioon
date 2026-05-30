using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client;

public sealed class NotificationsHttpRepo(HttpClient http)
    : HttpRepo<Notification>(http, "api/notifications"), INotificationsRepo;
