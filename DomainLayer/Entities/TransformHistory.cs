using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class TransformHistory
{
    public int RunId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public int FkSourceToolId { get; set; }

    public DateTime? StartDatetime { get; set; }

    public DateTime? EndDatetime { get; set; }

    public int FkStatus { get; set; }

    public virtual ICollection<Cvss> Cvsses { get; set; } = new List<Cvss>();

    public virtual ICollection<Cwe> Cwes { get; set; } = new List<Cwe>();

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    public virtual EnumSourceTool FkSourceTool { get; set; } = null!;

    public virtual EnumTransformStatus FkStatusNavigation { get; set; } = null!;

    public virtual ICollection<KnowledgeBase> KnowledgeBases { get; set; } = new List<KnowledgeBase>();

    public virtual ICollection<MasterFinding> MasterFindings { get; set; } = new List<MasterFinding>();

    public virtual ICollection<OrganizationalChart> OrganizationalCharts { get; set; } = new List<OrganizationalChart>();

    public virtual ICollection<Plugin> Plugins { get; set; } = new List<Plugin>();

    public virtual ICollection<QualysFinding> QualysFindings { get; set; } = new List<QualysFinding>();

    public virtual ICollection<Repository> Repositories { get; set; } = new List<Repository>();

    public virtual ICollection<Solution> Solutions { get; set; } = new List<Solution>();

    public virtual ICollection<TenableFinding> TenableFindings { get; set; } = new List<TenableFinding>();

    public virtual ICollection<TransformProcessHistory> TransformProcessHistories { get; set; } = new List<TransformProcessHistory>();
}
