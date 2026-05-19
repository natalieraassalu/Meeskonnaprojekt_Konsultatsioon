using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Abc.Data.Consultation;

namespace ConsApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Abc.Data.Consultation.Role> Role { get; set; }
        public DbSet<Abc.Data.Consultation.User> User { get; set; }
        public DbSet<Abc.Data.Consultation.UserRole> UserRole { get; set; }
        public DbSet<Abc.Data.Consultation.CourseSelector> CourseSelector { get; set; }
        public DbSet<Abc.Data.Consultation.Feedback> Feedback { get; set; }
        public DbSet<Abc.Data.Consultation.Material> Material { get; set; }
        public DbSet<Abc.Data.Consultation.Notification> Notification { get; set; }
        public DbSet<Abc.Data.Consultation.BookingPage> BookingPage { get; set; }
        public DbSet<Abc.Data.Consultation.ConsultationSlot> ConsultationSlot { get; set; }
        public DbSet<Abc.Data.Consultation.Course> Course { get; set; }
        public DbSet<Abc.Data.Consultation.CourseConsultation> CourseConsultation { get; set; }
        public DbSet<Abc.Data.Consultation.CourseMaterial> CourseMaterial { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            builder.Entity<Abc.Data.Consultation.Course>().Ignore(e => e.Timestamp);
            builder.Entity<Abc.Data.Consultation.Material>().Ignore(e => e.Timestamp);
            builder.Entity<Abc.Data.Consultation.Material>().Ignore(e => e.Number);
            builder.Entity<Abc.Data.Consultation.Material>().Ignore(e => e.Author);
            builder.Entity<Abc.Data.Consultation.CourseMaterial>().Ignore(e => e.Timestamp);
        }
    }
}