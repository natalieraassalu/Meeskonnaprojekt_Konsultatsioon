using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp;

public static class MaterialsApi
{
    public static IEndpointRouteBuilder MapMaterialsApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<Material, IMaterialsRepo>("/api/materials");
}
