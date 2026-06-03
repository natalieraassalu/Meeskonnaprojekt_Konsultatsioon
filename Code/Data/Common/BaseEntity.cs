using Abc.Aids;
using System.ComponentModel.DataAnnotations;

namespace Abc.Data.Common;

    public class BaseEntity
    {
    public virtual Guid Id { get; set; } = Guid.NewGuid(); //brauser gen id andmed serverile, pole edasi tagasi liiklust, guid unikaalne ka
    [Random(-50, -1)] public virtual DateTime? ValidFrom { get; set; } //saad tulevikku panna, aga ei saa minevikku panna, null tähendab, et kehtib alates loomisest
    [Random(2, 10)] public virtual DateTime? ValidTo { get; set; }
}

