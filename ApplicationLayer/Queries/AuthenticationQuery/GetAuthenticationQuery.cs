using DomainLayer.Entities;
using MediatR;
namespace ApplicationLayer.Queries.AuthenticationQuery
{
    public class GetAuthenticationQuery : IRequest<OrganizationalChart>
    {
        public string? userName { get; set; }   

    }
}
