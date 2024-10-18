﻿using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Cpe
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string FkCve { get; set; } = null!;

    public string? Cpe23uri { get; set; }

    public bool? Vulnerable { get; set; }

    public virtual Cvss FkCveNavigation { get; set; } = null!;
}