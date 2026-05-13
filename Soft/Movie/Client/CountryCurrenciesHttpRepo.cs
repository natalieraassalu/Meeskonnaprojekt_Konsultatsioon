using Abc.Data;
using Abc.Infra;

namespace Abc.Soft.Movie.Client;

public sealed class CountryCurrenciesHttpRepo(HttpClient http)
    : HttpRepo<CountryCurrency>(http, "api/countrycurrencies"), ICountryCurrenciesRepo;
