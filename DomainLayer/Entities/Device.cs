using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Device
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string? Name { get; set; }

    public string? InternalAxonId { get; set; }

    public string? Labels { get; set; }

    public string? NetworkInterfacesIps { get; set; }

    public string? NetworkInterfacesMac { get; set; }

    public string? OstypeDistribution { get; set; }

    public string? Ostype { get; set; }

    public string? LatestUsedUser { get; set; }

    public string? Owner { get; set; }

    public string? HostNameFqdn { get; set; }

    public string? SupportGroup { get; set; }

    public string? Umanager { get; set; }

    public string? AssignedTo { get; set; }

    public string? AssignedToEmail { get; set; }

    public string? AssignedToUserName { get; set; }

    public string? AssignedToManagerEmail { get; set; }

    public string? LastUsedUsersDepartmentsAssociation { get; set; }

    public string? FirstIp { get; set; }

    public string? FirstMacaddress { get; set; }

    public int? FkDeviceTypeId { get; set; }

    public int? FkPhysicalLocationId { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public virtual ICollection<DeviceAdapter> DeviceAdapters { get; set; } = new List<DeviceAdapter>();

    public virtual ICollection<DeviceIp> DeviceIps { get; set; } = new List<DeviceIp>();

    public virtual ICollection<DeviceLabel> DeviceLabels { get; set; } = new List<DeviceLabel>();

    public virtual ICollection<DeviceMac> DeviceMacs { get; set; } = new List<DeviceMac>();

    public virtual EnumDeviceType? FkDeviceType { get; set; }

    public virtual EnumDevicePhysicalLocation? FkPhysicalLocation { get; set; }

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual TransformHistory? FkRun { get; set; }

    public virtual ICollection<Host> Hosts { get; set; } = new List<Host>();
}
