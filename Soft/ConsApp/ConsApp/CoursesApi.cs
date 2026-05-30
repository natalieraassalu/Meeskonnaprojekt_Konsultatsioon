using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp;

public static class CoursesApi
{
    public static IEndpointRouteBuilder MapCoursesApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<Course, ICoursesRepo>("/api/courses");
}
