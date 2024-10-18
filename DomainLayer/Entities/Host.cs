using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Host
{
    public long Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string? HostUuid { get; set; }

    public string? HostUniqueness { get; set; }

    public string? HostName { get; set; }

    public string? Url { get; set; }

    public string? Domain { get; set; }

    public string? Dns { get; set; }

    public string? Ipv4address { get; set; }

    public string? Ipv6address { get; set; }

    public string? Macaddress { get; set; }

    public string? NetBios { get; set; }

    public string? OperatingSystem { get; set; }

    public string? Ssl { get; set; }

    public int FkSourceToolId { get; set; }

    public int? FkLocationId { get; set; }

    public int? FkApplicationId { get; set; }

    public long? FkDeviceId { get; set; }

    public virtual Application? FkApplication { get; set; }

    public virtual Device? FkDevice { get; set; }

    public virtual Location? FkLocation { get; set; }

    public virtual EnumSourceTool FkSourceTool { get; set; } = null!;

    public virtual ICollection<MasterFinding> MasterFindings { get; set; } = new List<MasterFinding>();

    public virtual ICollection<QualysFinding> QualysFindings { get; set; } = new List<QualysFinding>();

    public virtual ICollection<TenableFinding> TenableFindings { get; set; } = new List<TenableFinding>();
}
