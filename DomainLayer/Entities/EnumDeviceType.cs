using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class EnumDeviceType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
}
