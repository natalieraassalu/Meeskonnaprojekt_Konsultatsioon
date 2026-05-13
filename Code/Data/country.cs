using Abc.Aids;
using Abc.Data.Common;

namespace Abc.Data;

public sealed class Country : NamedEntity
{
    [Random(5, 16)] public string OfficialName { get; set; } = "";
    [Random(5, 16)] public string NativeName { get; set; } = "";
    [Random(3, 5, "0123456789")] public string NumericCode { get; set; } = "";
    bool IsIsoCountry { get; set; }
    bool IsLoyaltyProgram { get; set; }
    [Random(4, 5, "KLMNOPQRS")] public string IsoCode { get; set; } = "";
    public ICollection<CountryCurrency> CountryCurrencies { get; set; } = [];
    public ICollection<Currency> Currencies =>[.. CountryCurrencies.Select(c=>c.Currency)];

}