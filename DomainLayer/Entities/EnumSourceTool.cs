using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class EnumSourceTool
{
    public int Id { get; set; }

    public string EnumName { get; set; } = null!;

    public virtual ICollection<Host> Hosts { get; set; } = new List<Host>();

    public virtual ICollection<TransformHistory> TransformHistories { get; set; } = new List<TransformHistory>();

    public virtual ICollection<TransformProcessHistory> TransformProcessHistories { get; set; } = new List<TransformProcessHistory>();
}
