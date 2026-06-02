using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client;

public sealed class CourseSelectorsHttpRepo(HttpClient http)
    : HttpRepo<CourseSelector>(http, "api/courseselectors"), ICourseSelectorsRepo;

