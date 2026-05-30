using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client;

public sealed class RolesHttpRepo(HttpClient http)
    : HttpRepo<Role>(http, "api/roles"), IRolesRepo;
