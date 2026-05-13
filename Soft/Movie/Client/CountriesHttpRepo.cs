    using Abc.Data;
    using Abc.Infra;
    using global::Abc.Data;
    using global::Abc.Infra;

    namespace Abc.Soft.Movie.Client;

    public sealed class CountriesHttpRepo(HttpClient http)
        : HttpRepo<Country>(http, "api/countries"), ICountriesRepo;
