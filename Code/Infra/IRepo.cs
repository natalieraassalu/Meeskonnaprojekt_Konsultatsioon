using Abc.Data;
using Abc.Data.Common;
using Abc.Data.Consultation;

namespace Abc.Infra;

public interface IRepo<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetAsync(Guid id);
    Task<int> CountAsync(Query q);
    Task<IEnumerable<TEntity>> GetAsync(Query q);
    Task<TEntity> CreateAsync(TEntity e);
    Task<TEntity> UpdateAsync(TEntity e);
    Task DeleteAsync(Guid id);
}

public interface IMoviesRepo : IRepo<Movie> { }
public interface ICountriesRepo : IRepo<Country> { }
public interface ICurrenciesRepo : IRepo<Currency> { }
public interface IMoneyRepo : IRepo<Money> { }
public interface ICountryCurrenciesRepo : IRepo<CountryCurrency> { }
public interface ICoursesRepo : IRepo<Course> { }
public interface IMaterialsRepo : IRepo<Material> { }
public interface ICourseMaterialsRepo : IRepo<CourseMaterial> { }
public interface IUsersRepo : IRepo<User> { }
public interface IRolesRepo : IRepo<Role> { }
public interface IUserRolesRepo : IRepo<UserRole> { }
public interface IBookingPagesRepo : IRepo<BookingPage> { }
public interface IConsultationSlotsRepo : IRepo<ConsultationSlot> { }
public interface ICourseConsultationsRepo : IRepo<CourseConsultation> { }
public interface ICourseSelectorsRepo : IRepo<CourseSelector> { }
public interface IFeedbacksRepo : IRepo<Feedback> { }
public interface INotificationsRepo : IRepo<Notification> { }
public interface ICoursePostsRepo : IRepo<CoursePost> { }