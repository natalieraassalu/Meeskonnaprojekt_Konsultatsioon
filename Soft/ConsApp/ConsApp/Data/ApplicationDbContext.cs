using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Abc.Data.Consultation;

namespace ConsApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Abc.Data.Consultation.Role> Role { get; set; }
        public DbSet<Abc.Data.Consultation.Student> Student { get; set; }
        public DbSet<Abc.Data.Consultation.User> User { get; set; }
    }
}
