using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client.Repod;

public sealed class CoursesHttpRepo(HttpClient http)
    : HttpRepo<Course>(http, "api/courses"), ICoursesRepo;
