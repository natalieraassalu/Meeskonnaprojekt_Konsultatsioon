using Abc.Aids;
using Abc.Data.Common;

namespace Abc.Data;

public class CountryCurrency : DetailedEntity
{
    [Select(typeof(Country))]public Guid? CountryId { get; set; }
    [Select(typeof(Currency))] public Guid? CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public Country Country { get; set; }

}