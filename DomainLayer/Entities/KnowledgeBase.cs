using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class KnowledgeBase
{
    public long Qid { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string? VulnType { get; set; }

    public int? SeverityLevel { get; set; }

    public string? Title { get; set; }

    public string? Category { get; set; }

    public string? SoftwareList { get; set; }

    public string? Diagnosis { get; set; }

    public string? Consequence { get; set; }

    public string? Solution { get; set; }

    public string? Cvss { get; set; }

    public string? Cvssv3 { get; set; }

    public int? PciFlag { get; set; }

    public string? ThreatIntelligence { get; set; }

    public string? Discovery { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual TransformHistory? FkRun { get; set; }

    public virtual ICollection<KnowledgeBaseVulnerability> KnowledgeBaseVulnerabilities { get; set; } = new List<KnowledgeBaseVulnerability>();

    public virtual ICollection<QualysFinding> QualysFindings { get; set; } = new List<QualysFinding>();
}
