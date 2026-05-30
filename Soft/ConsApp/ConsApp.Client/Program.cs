using Abc.Infra;
using Abc.Soft.ConsApp.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICoursesRepo, CoursesHttpRepo>();
builder.Services.AddScoped<IMaterialsRepo, MaterialsHttpRepo>();
builder.Services.AddScoped<ICourseMaterialsRepo, CourseMaterialsHttpRepo>();
builder.Services.AddScoped<IConsultationSlotsRepo, ConsultationSlotsHttpRepo>();
builder.Services.AddScoped<IBookingPagesRepo, BookingPagesHttpRepo>();
builder.Services.AddScoped<ICourseConsultationsRepo, CourseConsultationsHttpRepo>();
builder.Services.AddScoped<IFeedbacksRepo, FeedbacksHttpRepo>();
builder.Services.AddScoped<INotificationsRepo, NotificationsHttpRepo>();
builder.Services.AddScoped<IRolesRepo, RolesHttpRepo>();
builder.Services.AddScoped<IUsersRepo, UsersHttpRepo>();
builder.Services.AddScoped<IUserRolesRepo, UserRolesHttpRepo>();
builder.Services.AddScoped<ICoursePostsRepo, CoursePostsHttpRepo>();

await builder.Build().RunAsync();
