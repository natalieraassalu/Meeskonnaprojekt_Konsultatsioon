using Abc.Data;
using Abc.Infra;

namespace Abc.Soft.Movie.Client;

public sealed class MoviesHttpRepo(HttpClient http)
    : HttpRepo<Data.Movie>(http, "api/movies"), IMoviesRepo;
