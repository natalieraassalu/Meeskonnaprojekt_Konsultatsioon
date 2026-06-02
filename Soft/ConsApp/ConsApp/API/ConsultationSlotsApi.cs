using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp.API;

public static class ConsultationSlotsApi
{
    public static IEndpointRouteBuilder MapConsultationSlotsApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<ConsultationSlot, IConsultationSlotsRepo>("/api/consultationslots");
}
