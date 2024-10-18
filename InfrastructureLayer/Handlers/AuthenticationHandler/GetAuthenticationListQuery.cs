using ApplicationLayer.Queries.EmployeeQuery;
using ApplicationLayer;
using DomainLayer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Queries.AuthenticationQuery;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Handlers.AuthenticationHandler
{
   
    public class GetAuthenticationListHandler : IRequestHandler<GetAuthenticationQuery, OrganizationalChart>
    {
        

        private readonly ApertureSilverDevContext appDbContext;
        public GetAuthenticationListHandler(ApertureSilverDevContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<OrganizationalChart> Handle(GetAuthenticationQuery request, CancellationToken cancellationToken)
        {
            return
         await appDbContext.OrganizationalCharts.Where(x => x.UserPrincipalName == request.userName).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        }

    }
}
