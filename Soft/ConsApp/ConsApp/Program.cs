using Abc.Infra;
using Abc.Soft.ConsApp;
using Abc.Soft.ConsApp.Components;
using Abc.Soft.ConsApp.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization();

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Single shared Abc.Infra context. The factory is used by the custom server-rendered
// pages (IDbContextFactory), while the scoped instance backs Identity + the EF repos.
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// IgnoreCycles so the CRUD Web APIs can serialize entities with navigation cycles.
builder.Services.ConfigureHttpJsonOptions(o =>
    o.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

// EF repositories (server-side implementations of the shared IRepo<T> contracts).
builder.Services.AddScoped<ICoursesRepo, CoursesRepo>();
builder.Services.AddScoped<IMaterialsRepo, MaterialsRepo>();
builder.Services.AddScoped<ICourseMaterialsRepo, CourseMaterialsRepo>();
builder.Services.AddScoped<IUsersRepo, UsersRepo>();
builder.Services.AddScoped<IRolesRepo, RolesRepo>();
builder.Services.AddScoped<IUserRolesRepo, UserRolesRepo>();
builder.Services.AddScoped<IBookingPagesRepo, BookingPagesRepo>();
builder.Services.AddScoped<IConsultationSlotsRepo, ConsultationSlotsRepo>();
builder.Services.AddScoped<ICourseConsultationsRepo, CourseConsultationsRepo>();
builder.Services.AddScoped<ICourseSelectorsRepo, CourseSelectorsRepo>();
builder.Services.AddScoped<IFeedbacksRepo, FeedbacksRepo>();    
builder.Services.AddScoped<ICoursePostsRepo, CoursePostsRepo>();

var app = builder.Build();

// Apply migrations and seed the two roles ("Lecturer", "Student") once on startup.
using (var scope = app.Services.CreateScope())
{
    var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
    using var context = dbFactory.CreateDbContext();
    await context.Database.MigrateAsync();

    if (!context.Role.Any(r => r.Name == "Lecturer"))
    {
        context.Role.Add(new Abc.Data.Consultation.Role { Name = "Lecturer" });
    }
    if (!context.Role.Any(r => r.Name == "Student"))
    {
        context.Role.Add(new Abc.Data.Consultation.Role { Name = "Student" });
    }
    await context.SaveChangesAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Abc.Soft.ConsApp.Client._Imports).Assembly);

// CRUD Web API endpoints (one MapXApi per entity).
app.MapCoursesApi();
app.MapMaterialsApi();
app.MapCourseMaterialsApi();
app.MapConsultationSlotsApi();
app.MapBookingPagesApi();
app.MapCourseConsultationsApi();
app.MapFeedbacksApi();
app.MapRolesApi();
app.MapUsersApi();
app.MapUserRolesApi();
app.MapCoursePostsApi();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
