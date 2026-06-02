using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client.Repod;

public sealed class CourseMaterialsHttpRepo(HttpClient http)
    : HttpRepo<CourseMaterial>(http, "api/coursematerials"), ICourseMaterialsRepo;
