using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client;

public sealed class CourseConsultationsHttpRepo(HttpClient http)
    : HttpRepo<CourseConsultation>(http, "api/courseconsultations"), ICourseConsultationsRepo;
