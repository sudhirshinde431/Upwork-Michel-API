using DomainLayer.Entities;
using DomainLayer.Models;
using MediatR;
namespace ApplicationLayer.Queries.EmployeeQuery
{
    public class GetReportingListQuery : IRequest<List<GetReportings>>{
        public int ManagerId { get; set; }      
    }
    public class GetOrgnisationdetailesByIdQuery : IRequest<OrganizationalChart>
     {
        public int ID { get; set; }
        public string UserPrincipalName { get; set; }
    }

    public class Organizational_VulnerabilityQuery : IRequest<List<OrganizationalVulnerability>>    {
        public int OrganizationalId { get; set; }
    }
}
