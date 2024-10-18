using ApplicationLayer;
using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace InfrastructureLayer.Handlers.EmployeeHandler
{
    public class GetOrganizationalChartListHandler : IRequestHandler<GetOrganizationalChartListQuery, PagedList<OrganizationalChart>>
    {
        private readonly dynamic appDbContext;
        //public GetOrganizationalChartListHandler(ApertureSilverDevContext appDbContext)
        //{
        //    this.appDbContext = appDbContext;
        //}
        public async Task<PagedList<OrganizationalChart>> Handle(GetOrganizationalChartListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<OrganizationalChart> deviceQuery = appDbContext.OrganizationalCharts;
            if (!string.IsNullOrWhiteSpace(request.searchTerm))
            {
                deviceQuery = deviceQuery.Where(p =>
                  p.GivenName.Contains(request.searchTerm) ||
                  ((string)p.Fullname).Contains(request.searchTerm) ||
                  ((string)p.Department).Contains(request.searchTerm)
                );
            }

            if (request.sortOrder?.ToLower() == "desc")
            {
                deviceQuery = deviceQuery.OrderByDescending(GetSortProperty(request));
            }
            else
            {
                deviceQuery = deviceQuery.OrderBy(GetSortProperty(request));
            }
            var products = await PagedList<OrganizationalChart>.CreateAsync(
              deviceQuery,
              request.page,
              request.pageSize);

            return products;

        }

        private static Expression<Func<OrganizationalChart, object>> GetSortProperty(GetOrganizationalChartListQuery request) =>
        request.sortColumn?.ToLower() switch
        {
            "CreatedAt" => product => product.CreatedAt,
            "ModifiedAt" => product => product.ModifiedAt,
            "GivenName" => product => product.GivenName,
            "JobTitle" => product => product.JobTitle,
            "Fullname" => product => product.Fullname,
            _ => product => product.Id
        };

    
    }
}
