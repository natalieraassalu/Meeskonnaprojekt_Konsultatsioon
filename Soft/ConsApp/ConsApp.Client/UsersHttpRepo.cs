using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client;

public sealed class UsersHttpRepo(HttpClient http)
    : HttpRepo<User>(http, "api/users"), IUsersRepo;
