using Abc.Infra;
using Abc.Soft.Movie.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthenticationStateDeserialization();
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICountriesRepo, CountriesHttpRepo>();
builder.Services.AddScoped<IMoviesRepo, MoviesHttpRepo>();
builder.Services.AddScoped<ICurrenciesRepo, CurrenciesHttpRepo>();
builder.Services.AddScoped<IMoneyRepo, MoneyHttpRepo>();
builder.Services.AddScoped<ICountryCurrenciesRepo, CountryCurrenciesHttpRepo>();

await builder.Build().RunAsync();