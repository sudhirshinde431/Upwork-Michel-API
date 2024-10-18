using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Cvss
{
    public int Id { get; set; }

    public string Cve { get; set; } = null!;

    public bool? Published { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public string? AttackComplexity3 { get; set; }

    public string? AttackVector3 { get; set; }

    public string? AvailabilityImpact3 { get; set; }

    public string? ConfidentialityImpact3 { get; set; }

    public string? IntegrityImpact3 { get; set; }

    public string? PrivilegesRequired3 { get; set; }

    public string? Scope3 { get; set; }

    public string? UserInteraction3 { get; set; }

    public string? VectorString3 { get; set; }

    public double? ExloitabilityScore3 { get; set; }

    public double? ImpactScore3 { get; set; }

    public double? BaseScore3 { get; set; }

    public string? BaseSeverity3 { get; set; }

    public string? AccessComplexity { get; set; }

    public string? AccessVector { get; set; }

    public string? Authentication { get; set; }

    public string? AvailabilityImpact { get; set; }

    public string? ConfidentialityImpact { get; set; }

    public string? IntegrityImpact { get; set; }

    public bool? ObtainAllPrivileges { get; set; }

    public bool? ObtainOtherPrivileges { get; set; }

    public bool? ObtainUserPrivileges { get; set; }

    public bool? UserInteractionRequired { get; set; }

    public string? VectorString { get; set; }

    public double? ExploitabilityScore { get; set; }

    public double? ImpactScore { get; set; }

    public double? BaseScore { get; set; }

    public string? Severity { get; set; }

    public string? Description { get; set; }

    public DateTime? PublishedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public virtual ICollection<Cpe> Cpes { get; set; } = new List<Cpe>();

    public virtual ICollection<Cveproblem> Cveproblems { get; set; } = new List<Cveproblem>();

    public virtual ICollection<Cvereference> Cvereferences { get; set; } = new List<Cvereference>();

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual TransformHistory? FkRun { get; set; }

    public virtual ICollection<MasterFindingCve> MasterFindingCves { get; set; } = new List<MasterFindingCve>();
}
