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