using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class TenableFinding
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateOnly CreatedAtDate { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string? Hash { get; set; }

    public string? HashUniqueness { get; set; }

    public string? Uuid { get; set; }

    public bool? HasBeenMitigated { get; set; }

    public bool? AcceptRisk { get; set; }

    public bool? RecastRisk { get; set; }

    public int? FirstSeen { get; set; }

    public DateTime? FirstSeenDateTime { get; set; }

    public DateOnly? FirstSeenDate { get; set; }

    public int? LastSeen { get; set; }

    public DateOnly? LastSeenDate { get; set; }

    public string? RecastRiskRuleComment { get; set; }

    public string? AcceptRiskRuleComment { get; set; }

    public string? AssetExposureScore { get; set; }

    public string? RiskFactor { get; set; }

    public string? Version { get; set; }

    public string? Cve { get; set; }

    public string? Bid { get; set; }

    public string? Xref { get; set; }

    public string? KeyDrivers { get; set; }

    public string? Protocol { get; set; }

    public int? Port { get; set; }

    public long FkMasterFindingId { get; set; }

    public long FkHostId { get; set; }

    public int? FkRepositoryId { get; set; }

    public int? FkTenableSeverityId { get; set; }

    public int? FkFamilyId { get; set; }

    public long FkPluginId { get; set; }

    public string? PluginInfo { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public virtual ICollection<FindingVulnerability> FindingVulnerabilities { get; set; } = new List<FindingVulnerability>();

    public virtual Family? FkFamily { get; set; }

    public virtual Host FkHost { get; set; } = null!;

    public virtual MasterFinding FkMasterFinding { get; set; } = null!;

    public virtual Plugin FkPlugin { get; set; } = null!;

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual Repository? FkRepository { get; set; }

    public virtual TransformHistory? FkRun { get; set; }

    public virtual Severity1? FkTenableSeverity { get; set; }
}
