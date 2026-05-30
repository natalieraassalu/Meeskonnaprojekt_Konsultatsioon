using Abc.Data;
using Abc.Data.Consultation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Abc.Infra;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :IdentityDbContext<ApplicationUser>(options){
    public DbSet<Movie> Movies { get; set; } = default!;
    public DbSet<Country> Countries { get; set; } = default!;
    public DbSet<Currency> Currencies { get; set; } = default!;
    public DbSet<Money> Money { get; set; } = default!;
    public DbSet<CountryCurrency> CountryCurrencies { get; set; } = default!;
    public DbSet<Course> Courses { get; set; } = default!;
    public DbSet<Material> Materials { get; set; } = default!;
    public DbSet<CourseMaterial> CourseMaterials { get; set; } = default!;
    public DbSet<User> User { get; set; } = default!;
    public DbSet<Role> Role { get; set; } = default!;
    public DbSet<UserRole> UserRole { get; set; } = default!;
    public DbSet<ConsultationSlot> ConsultationSlot { get; set; } = default!;
    public DbSet<BookingPage> BookingPage { get; set; } = default!;
    public DbSet<CourseSelector> CourseSelector { get; set; } = default!;
    public DbSet<CourseConsultation> CourseConsultation { get; set; } = default!;
    public DbSet<Feedback> Feedback { get; set; } = default!;
    public DbSet<Notification> Notification { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder b) {
         base.OnModelCreating(b);
         b.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
