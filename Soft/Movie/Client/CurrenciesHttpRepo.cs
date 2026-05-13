using Abc.Data;
using Abc.Infra;

namespace Abc.Soft.Movie.Client;

public sealed class CurrenciesHttpRepo(HttpClient http)
    : HttpRepo<Currency>(http, "api/currencies"), ICurrenciesRepo;