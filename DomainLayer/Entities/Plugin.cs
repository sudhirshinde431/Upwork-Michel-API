using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Plugin
{
    public long PluginId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? RequiredPorts { get; set; }

    public string? RequiredUdpports { get; set; }

    public string? Cpe { get; set; }

    public string? Srcport { get; set; }

    public string? Dstport { get; set; }

    public string? Protocol { get; set; }

    public string? Solution { get; set; }

    public string? SeeAlso { get; set; }

    public string? Synopsis { get; set; }

    public string? CheckType { get; set; }

    public string? ExploitEase { get; set; }

    public bool? ExploitAvailable { get; set; }

    public string? ExploitFrameworks { get; set; }

    public string? Cvssvector { get; set; }

    public double? CvssvectorBf { get; set; }

    public double? BaseScore { get; set; }

    public double? TemporalScore { get; set; }

    public string? Cvssv3vector { get; set; }

    public double? Cvssv3vectorBf { get; set; }

    public double? Cvssv3baseScore { get; set; }

    public double? Cvssv3temporalScore { get; set; }

    public double? VprScore { get; set; }

    public string? VprContext { get; set; }

    public string? StigSeverity { get; set; }

    public int? PluginPubDate { get; set; }

    public int? PluginModDate { get; set; }

    public int? PatchPubDate { get; set; }

    public int? PatchModDate { get; set; }

    public int? VulnPubDate { get; set; }

    public int? FkFamilyId { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public virtual Family? FkFamily { get; set; }

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual TransformHistory? FkRun { get; set; }

    public virtual ICollection<Solution> Solutions { get; set; } = new List<Solution>();

    public virtual ICollection<TenableFinding> TenableFindings { get; set; } = new List<TenableFinding>();
}
