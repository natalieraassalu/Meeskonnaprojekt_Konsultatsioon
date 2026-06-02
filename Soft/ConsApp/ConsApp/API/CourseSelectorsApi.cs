using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp.API;

public static class CourseSelectorsApi
{
    public static IEndpointRouteBuilder MapCourseSelectorsApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<CourseSelector, ICourseSelectorsRepo>("/api/courseselectors");
}

