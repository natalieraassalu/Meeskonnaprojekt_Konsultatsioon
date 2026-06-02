using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp.API;

public static class CoursePostsApi
{
    public static IEndpointRouteBuilder MapCoursePostsApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<CoursePost, ICoursePostsRepo>("/api/courseposts");
}
