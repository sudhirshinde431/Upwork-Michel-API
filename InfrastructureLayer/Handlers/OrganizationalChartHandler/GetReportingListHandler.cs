using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using DomainLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InfrastructureLayer.Handlers.OrganizationalChartHandler
{

    public class GetReportingListHandler : IRequestHandler<GetReportingListQuery, List<GetReportings>>,
        IRequestHandler<GetOrgnisationdetailesByIdQuery, OrganizationalChart>,
                IRequestHandler<Organizational_VulnerabilityQuery, List<OrganizationalVulnerability>>
    {
        private readonly ApertureSilverDevContext appDbContext;
        public GetReportingListHandler(ApertureSilverDevContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<GetReportings>> Handle(GetReportingListQuery request, CancellationToken cancellationToken)
        {
            List<GetReportings> _GetReportings = new List<GetReportings>();

            _GetReportings = await appDbContext.OrganizationalCharts.Where(x => x.ManagerId == request.ManagerId).Select(x => new GetReportings
            {
                Id = x.Id,
                ManagerId = x.ManagerId,
                CreatedAt = x.CreatedAt,
                Department = x.Department,
                GivenName = x.GivenName,
                JobTitle = x.JobTitle,
                Surname = x.Surname,
                Notification = appDbContext.OrganizationalVulnerabilities.Where(z => z.Organizational == x.Id).Select(z=>z.Notification).SingleOrDefault(),
                TotalVulnerability = appDbContext.OrganizationalVulnerabilities.Where(z => z.Organizational == x.Id).Select(z => z.TotalVulnerability).SingleOrDefault(),
                OrphanedAsset = appDbContext.OrganizationalVulnerabilities.Where(z => z.Organizational == x.Id).Select(z => z.OrphanedAsset).SingleOrDefault(),
                TotalOwnedApp = appDbContext.OrganizationalVulnerabilities.Where(z => z.Organizational == x.Id).Select(z => z.TotalOwnedApp).SingleOrDefault(),

            }).ToListAsync(cancellationToken: cancellationToken);


            // .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return _GetReportings;

        }



        public async Task<OrganizationalChart> Handle(GetOrgnisationdetailesByIdQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.UserPrincipalName))
            {
                return
             await appDbContext.OrganizationalCharts.Where(x => x.UserPrincipalName == request.UserPrincipalName).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            }
            else
            {
                return
             await appDbContext.OrganizationalCharts.Where(x => x.Id == request.ID).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            }
         
            
        }
         
        public async Task<List<OrganizationalVulnerability>> Handle(Organizational_VulnerabilityQuery request, CancellationToken cancellationToken)
          => await appDbContext.OrganizationalVulnerabilities.Where(x => x.Organizational == request.OrganizationalId).ToListAsync(cancellationToken: cancellationToken);

    }


}