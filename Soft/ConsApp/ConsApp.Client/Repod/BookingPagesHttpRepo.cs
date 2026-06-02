using Abc.Data.Consultation;
using Abc.Infra;

namespace Abc.Soft.ConsApp.Client.Repod;

public sealed class BookingPagesHttpRepo(HttpClient http)
    : HttpRepo<BookingPage>(http, "api/bookingpages"), IBookingPagesRepo;
