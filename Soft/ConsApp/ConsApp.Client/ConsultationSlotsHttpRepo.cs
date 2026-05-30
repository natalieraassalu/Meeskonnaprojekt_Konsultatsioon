using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client;

public sealed class ConsultationSlotsHttpRepo(HttpClient http)
    : HttpRepo<ConsultationSlot>(http, "api/consultationslots"), IConsultationSlotsRepo;
