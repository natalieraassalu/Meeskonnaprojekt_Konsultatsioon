using Abc.Aids;
using Abc.Data;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infra;

public sealed class SeedDb(ApplicationDbContext db, int recCnt = 20)
{
    public async Task Seed()
    {
        await db.Database.MigrateAsync();

        await seedTable(db.Currencies, [
            nameof(Currency.Timestamp)]);

        await seedTable(db.Countries, [
            nameof(Country.CountryCurrencies),
            nameof(Country.Currencies),
            nameof(Country.Timestamp)]);

        await seedTable(db.Money, [
            nameof(Money.CurrencyId),
            nameof(Money.Currency),
            nameof(Money.Timestamp)]);

        await seedTable(db.CountryCurrencies, [
            nameof(CountryCurrency.CurrencyId),
            nameof(CountryCurrency.CountryId),
            nameof(CountryCurrency.Currency),
            nameof(CountryCurrency.Country),
            nameof(CountryCurrency.Timestamp)]);

        await seedTable(db.Movies, [
            nameof(Movie.Country),
            nameof(Movie.Money),
            nameof(Movie.Timestamp)]);
    }

    private async Task seedTable<T>(DbSet<T> set, string[] exclude = null) where T : class
    {
        if (set.Any()) return;
        var items = new List<T>();
        for (var i = 1; i <= recCnt; i++)
        {
            var item = (T)GetRandom.Object(typeof(T), exclude);
            items.Add(item);
            if (items.Count % 100 != 0) continue;
            await set.AddRangeAsync(items);
            await db.SaveChangesAsync();
            items = [];
        }
        await set.AddRangeAsync(items);
        await db.SaveChangesAsync();
    }
}