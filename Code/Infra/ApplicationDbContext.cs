using Abc.Data;
using Abc.Data.Consultation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<Currency> Currencies { get; set; } = default!;
        public DbSet<Money> Money { get; set; } = default!;
        public DbSet<CountryCurrency> CountryCurrencies { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Material> Materials { get; set; } = default!;
        public DbSet<CourseMaterial> CourseMaterials { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<UserRole> UserRoles { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            b.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
