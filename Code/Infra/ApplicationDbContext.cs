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
    public DbSet<CoursePost> CoursePost { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder b) {
         base.OnModelCreating(b);
         b.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

         // Consultation-specific mapping (ported from the former ConsApp.Data context),
         // scoped to Abc.Data.Consultation entities so Movie's mapping is untouched.
         // These three entities carry a [Timestamp] rowversion that ConsApp does not persist.
         b.Entity<Course>().Ignore(e => e.Timestamp);
         b.Entity<Material>().Ignore(e => e.Timestamp);
         b.Entity<CourseMaterial>().Ignore(e => e.Timestamp);

         // Disable cascade delete on consultation FKs to avoid multiple-cascade-path errors.
         foreach (var relationship in b.Model.GetEntityTypes()
                      .Where(e => e.ClrType.Namespace == "Abc.Data.Consultation")
                      .SelectMany(e => e.GetForeignKeys()))
         {
             relationship.DeleteBehavior = DeleteBehavior.NoAction;
         }
    }
}
