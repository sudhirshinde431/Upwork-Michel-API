using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Solution
{
    public string SolutionId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string? Cpe { get; set; }

    public string? Solution1 { get; set; }

    public string? RemediationList { get; set; }

    public int? Total { get; set; }

    public string? TotalPctg { get; set; }

    public string? ScorePctg { get; set; }

    public int? HostTotal { get; set; }

    public int? MsbulletInTotal { get; set; }

    public int? Cvetotal { get; set; }

    public double? Vprscore { get; set; }

    public double? Cvssv3baseScore { get; set; }

    public long FkPluginId { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public virtual Plugin FkPlugin { get; set; } = null!;

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual TransformHistory? FkRun { get; set; }
}
