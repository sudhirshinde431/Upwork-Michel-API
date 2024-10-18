using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class MasterFinding
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateOnly CreatedAtDate { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int FkSeverityId { get; set; }

    public long FkHostId { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public virtual Host FkHost { get; set; } = null!;

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual TransformHistory? FkRun { get; set; }

    public virtual Severity FkSeverity { get; set; } = null!;

    public virtual ICollection<MasterFindingCve> MasterFindingCves { get; set; } = new List<MasterFindingCve>();

    public virtual ICollection<MasterFindingCwe> MasterFindingCwes { get; set; } = new List<MasterFindingCwe>();

    public virtual ICollection<QualysFinding> QualysFindings { get; set; } = new List<QualysFinding>();

    public virtual ICollection<TenableFinding> TenableFindings { get; set; } = new List<TenableFinding>();
}
