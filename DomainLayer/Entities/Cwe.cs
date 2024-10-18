using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Cwe
{
    public int Id { get; set; }

    public string? Cwe1 { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public string Name { get; set; } = null!;

    public string? Weakness { get; set; }

    public string? Abstraction { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public string? ExtendedDescription { get; set; }

    public string? RelatedWeaknesses { get; set; }

    public string? WeaknessOrdinalities { get; set; }

    public string? ApplicablePlatforms { get; set; }

    public string? BackgroundDetails { get; set; }

    public string? AlternateTerms { get; set; }

    public string? ModesOfIntroduction { get; set; }

    public string? ExploitationFactors { get; set; }

    public string? LikelihoodOfExploit { get; set; }

    public string? CommonConsequences { get; set; }

    public string? DetectionMethods { get; set; }

    public string? PotentialMitigations { get; set; }

    public string? ObservedExamples { get; set; }

    public string? FunctionalAreas { get; set; }

    public string? AffectedResources { get; set; }

    public string? TaxonomyMappings { get; set; }

    public string? RelatedAttackPatterns { get; set; }

    public string? Notes { get; set; }

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual TransformHistory? FkRun { get; set; }

    public virtual ICollection<MasterFindingCwe> MasterFindingCwes { get; set; } = new List<MasterFindingCwe>();
}
