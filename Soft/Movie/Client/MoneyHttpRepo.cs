using Abc.Data;
using Abc.Infra;

namespace Abc.Soft.Movie.Client;

public sealed class MoneyHttpRepo(HttpClient http)
    : HttpRepo<Money>(http, "api/money"), IMoneyRepo;

