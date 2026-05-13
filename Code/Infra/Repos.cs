using Abc.Data;
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

