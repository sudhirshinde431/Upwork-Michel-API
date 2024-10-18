using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class MasterFindingCve
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public long? FkFindingId { get; set; }

    public int? FkCveid { get; set; }

    public string? Cve { get; set; }

    public virtual Cvss? FkCve { get; set; }

    public virtual MasterFinding? FkFinding { get; set; }
}
