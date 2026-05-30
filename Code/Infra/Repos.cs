using Abc.Data;
using Abc.Data.Consultation;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra;

public class MoviesRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, Movie>(c), IMoviesRepo
{ }
public class CurrenciesRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, Currency>(c), ICurrenciesRepo
{ }
public class CountriesRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, Country>(c), ICountriesRepo
{
    protected override IQueryable<Country> Query() => db.Countries
        .Include(x => x.CountryCurrencies)
        .ThenInclude(x => x.Currency);
}
public class MoneyRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, Money>(c), IMoneyRepo
{ }
public class CountryCurrenciesRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, CountryCurrency>(c), ICountryCurrenciesRepo
{
    protected override IQueryable<CountryCurrency> Query() => db.CountryCurrencies
        .Include(x => x.Country)
        .Include(x => x.Currency);
}
public class CoursesRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, Course>(c), ICoursesRepo
{
    protected override IQueryable<Course> Query() => db.Courses
        .Include(x => x.CourseMaterials)
        .ThenInclude(x => x.Material);
}
public class MaterialsRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, Material>(c), IMaterialsRepo
{
    protected override IQueryable<Material> Query() => db.Materials
        .Include(x => x.CourseMaterials)
        .ThenInclude(x => x.Course);
}
public class CourseMaterialsRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, CourseMaterial>(c), ICourseMaterialsRepo
{
    protected override IQueryable<CourseMaterial> Query() => db.CourseMaterials
        .Include(x => x.Course)
        .Include(x => x.Material);
}
public class UsersRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, User>(c), IUsersRepo
{
    protected override IQueryable<User> Query() => db.User;
}

public class RolesRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, Role>(c), IRolesRepo
{
    protected override IQueryable<Role> Query() => db.Role;
}

public class UserRolesRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, UserRole>(c), IUserRolesRepo
{
    protected override IQueryable<UserRole> Query() => db.UserRole
        .Include(x => x.User)
        .Include(x => x.Role);
}

public class BookingPagesRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, BookingPage>(c), IBookingPagesRepo
{
    protected override IQueryable<BookingPage> Query() => db.BookingPage
        .Include(x => x.Slot)
        .Include(x => x.Student);
}

public class ConsultationSlotsRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, ConsultationSlot>(c), IConsultationSlotsRepo
{
    protected override IQueryable<ConsultationSlot> Query() => db.ConsultationSlot
        .Include(x => x.Lecturer);
}

public class CourseConsultationsRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, CourseConsultation>(c), ICourseConsultationsRepo
{ }

public class CourseSelectorsRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, CourseSelector>(c), ICourseSelectorsRepo
{
    protected override IQueryable<CourseSelector> Query() => db.CourseSelector
        .Include(x => x.Course)
        .Include(x => x.Lecturer)
        .Include(x => x.Student);
}

public class FeedbacksRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, Feedback>(c), IFeedbacksRepo
{ }

public class NotificationsRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, Notification>(c), INotificationsRepo
{
    protected override IQueryable<Notification> Query() => db.Notification
        .Include(x => x.ConsultationSlot)
        .Include(x => x.Lecturer)
        .Include(x => x.Student);
}

public class CoursePostsRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, CoursePost>(c), ICoursePostsRepo
{ }

