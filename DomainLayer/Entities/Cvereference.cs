using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Cvereference
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string FkCve { get; set; } = null!;

    public string? Url { get; set; }

    public string? Source { get; set; }

    public virtual Cvss FkCveNavigation { get; set; } = null!;
}
