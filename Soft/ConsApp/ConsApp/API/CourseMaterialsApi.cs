using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp.API;

public static class CourseMaterialsApi
{
    public static IEndpointRouteBuilder MapCourseMaterialsApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<CourseMaterial, ICourseMaterialsRepo>("/api/coursematerials");
}
