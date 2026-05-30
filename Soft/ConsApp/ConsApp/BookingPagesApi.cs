using Abc.Data.Consultation;
using Abc.Infra;
using Microsoft.AspNetCore.Routing;

namespace Abc.Soft.ConsApp;

public static class BookingPagesApi
{
    public static IEndpointRouteBuilder MapBookingPagesApi(this IEndpointRouteBuilder app)
        => app.MapCrudApi<BookingPage, IBookingPagesRepo>("/api/bookingpages");
}
