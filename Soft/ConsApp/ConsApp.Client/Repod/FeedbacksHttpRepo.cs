using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client.Repod;

public sealed class FeedbacksHttpRepo(HttpClient http)
    : HttpRepo<Feedback>(http, "api/feedbacks"), IFeedbacksRepo;
