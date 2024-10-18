using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class MasterFindingCwe
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public long? FkFindingId { get; set; }

    public int? FkCweid { get; set; }

    public string? Cwe { get; set; }

    public virtual Cwe? FkCwe { get; set; }

    public virtual MasterFinding? FkFinding { get; set; }
}
