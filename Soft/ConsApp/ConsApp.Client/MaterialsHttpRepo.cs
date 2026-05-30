using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client;

public sealed class MaterialsHttpRepo(HttpClient http)
    : HttpRepo<Material>(http, "api/materials"), IMaterialsRepo;
