using Abc.Aids;
using Abc.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Abc.Data;

public class Money : BaseEntity
{
    [Random(0, 100, 2)] public decimal Amount { get; set; }
    public Guid? CurrencyId { get; set; }
    public Currency Currency { get; set; }
    [Timestamp] public byte[] Timestamp { get; set; } = [];
}