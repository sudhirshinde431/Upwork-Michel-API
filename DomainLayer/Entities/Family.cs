using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Family
{
    public int FamilyId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Plugin> Plugins { get; set; } = new List<Plugin>();

    public virtual ICollection<TenableFinding> TenableFindings { get; set; } = new List<TenableFinding>();
}
