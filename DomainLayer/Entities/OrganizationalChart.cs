using System;
using System.Collections.Generic;

namespace DomainLayer.Entities;

public partial class OrganizationalChart
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool? Tombstone { get; set; }

    public string? GivenName { get; set; }

    public string? Surname { get; set; }

    public string? Fullname { get; set; }

    public string? JobTitle { get; set; }

    public string? UserPrincipalName { get; set; }

    public string? SamAccountName { get; set; }

    public string? Department { get; set; }

    public string? Email { get; set; }

    public string? Manager { get; set; }

    public string? ManagerFullName { get; set; }

    public long? ManagerId { get; set; }

    public int? FkRunId { get; set; }

    public int? FkProcessId { get; set; }

    public virtual TransformProcessHistory? FkProcess { get; set; }

    public virtual TransformHistory? FkRun { get; set; }
}
