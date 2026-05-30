using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp;

public static class FeedbacksApi
{
    public static IEndpointRouteBuilder MapFeedbacksApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<Feedback, IFeedbacksRepo>("/api/feedbacks");
}
