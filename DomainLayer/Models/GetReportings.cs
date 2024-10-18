using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
   public class GetReportings
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

        public long TotalOwnedApp { get; set; }

        public long TotalVulnerability { get; set; }

        public long OrphanedAsset { get; set; }

        public long Notification { get; set; }

       
    }
}
