using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client;

public sealed class FeedbacksHttpRepo(HttpClient http)
    : HttpRepo<Feedback>(http, "api/feedbacks"), IFeedbacksRepo;
