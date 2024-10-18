using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Severity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Value { get; set; }

    public string? Description { get; set; }

    public bool IsInternal { get; set; }

    public virtual ICollection<MasterFinding> MasterFindings { get; set; } = new List<MasterFinding>();
}
