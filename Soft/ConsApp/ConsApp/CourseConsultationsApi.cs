using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp;

public static class CourseConsultationsApi
{
    public static IEndpointRouteBuilder MapCourseConsultationsApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<CourseConsultation, ICourseConsultationsRepo>("/api/courseconsultations");
}
