using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Location
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Host> Hosts { get; set; } = new List<Host>();
}
