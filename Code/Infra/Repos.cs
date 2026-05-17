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
        .Include(x => x.CourseMaterial)
        .ThenInclude(x => x.Material);
}
public class MaterialsRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, Material>(c), IMaterialsRepo
{
    protected override IQueryable<Material> Query() => db.Materials
        .Include(x => x.CourseMaterial)
        .ThenInclude(x => x.Course);
}
public class CourseMaterialsRepo(ApplicationDbContext c = null)
    : EfBaseRepo<ApplicationDbContext, CourseMaterial>(c), ICourseMaterialsRepo
{
    protected override IQueryable<CourseMaterial> Query() => db.CourseMaterials
        .Include(x => x.Course)
        .Include(x => x.Material);
}

