using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client.Repod;

public sealed class CoursePostsHttpRepo(HttpClient http)
    : HttpRepo<CoursePost>(http, "api/courseposts"), ICoursePostsRepo;
