using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class QualysFinding
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateOnly CreatedAtDate { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public long FkMasterFindingId { get; set; }

    public long FkHostId { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public long FkQid { get; set; }

    public long? UniqueVulnId { get; set; }

    public string? Type { get; set; }

    public int? Severity { get; set; }

    public string? Status { get; set; }

    public string? Results { get; set; }

    public DateTime? FirstFoundDatetime { get; set; }

    public DateTime? LastFoundDatetime { get; set; }

    public string? Source { get; set; }

    public int? TimesFound { get; set; }

    public DateTime? LastTestDatetime { get; set; }

    public DateTime? LastUpdateDatetime { get; set; }

    public bool? IsIgnored { get; set; }

    public bool? IsDisabled { get; set; }

    public DateTime? LastProcessedDatetime { get; set; }

    public virtual Host FkHost { get; set; } = null!;

    public virtual MasterFinding FkMasterFinding { get; set; } = null!;

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual KnowledgeBase FkQ { get; set; } = null!;

    public virtual TransformHistory? FkRun { get; set; }
}
