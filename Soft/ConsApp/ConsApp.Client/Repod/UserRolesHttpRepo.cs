using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client.Repod;

public sealed class UserRolesHttpRepo(HttpClient http)
    : HttpRepo<UserRole>(http, "api/userroles"), IUserRolesRepo;
