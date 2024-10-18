using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Severity1
{
    public int SeverityId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TenableFinding> TenableFindings { get; set; } = new List<TenableFinding>();
}
