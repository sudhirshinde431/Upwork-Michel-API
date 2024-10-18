using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class Log
{
    public int LogId { get; set; }

    public string MachineName { get; set; } = null!;

    public string Level { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string Logger { get; set; } = null!;

    public string Callsite { get; set; } = null!;

    public string Exception { get; set; } = null!;

    public DateTime Logged { get; set; }
}
