using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class DeviceMac
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public long? FkDeviceId { get; set; }

    public string Mac { get; set; } = null!;

    public virtual Device? FkDevice { get; set; }
}
