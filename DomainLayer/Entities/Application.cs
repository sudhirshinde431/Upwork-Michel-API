using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Application
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Host> Hosts { get; set; } = new List<Host>();
}
