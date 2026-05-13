using Abc.Aids;
using Abc.Data.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.Data;

    public class Movie:NamedEntity
{
    [DisplayName("Title")] public override string Name { get; set; }
    [DisplayName("ReleaseDate")] public override DateTime? ValidFrom { get; set; }
    [Random(5, 15)] public string Genre { get; set; }
    [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
    [Random(0, 5, 2)] public decimal Price { get; set; }
    public Money Money { get; set; }
    public Country Country { get; set; }
    [Timestamp] public byte[] Timestamp { get; set; } = [];
}