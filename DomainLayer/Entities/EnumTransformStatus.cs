using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class EnumTransformStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<TransformHistory> TransformHistories { get; set; } = new List<TransformHistory>();

    public virtual ICollection<TransformProcessHistory> TransformProcessHistories { get; set; } = new List<TransformProcessHistory>();
}
