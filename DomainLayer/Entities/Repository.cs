using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Repository
{
    public int RepositoryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Uuid { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual TransformHistory? FkRun { get; set; }

    public virtual ICollection<TenableFinding> TenableFindings { get; set; } = new List<TenableFinding>();
}
