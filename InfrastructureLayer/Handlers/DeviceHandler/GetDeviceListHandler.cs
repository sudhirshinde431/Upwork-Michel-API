using ApplicationLayer;
using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace InfrastructureLayer.Handlers.EmployeeHandler
{
    public class GetDeviceListHandler : IRequestHandler<GetDeviceListQuery, PagedList<Device>>
    {
        private readonly dynamic appDbContext;
        //public GetDeviceListHandler(ApertureSilverDevContext appDbContext)
        //{
        //    this.appDbContext = appDbContext;
        //}
        public async Task<PagedList<Device>> Handle(GetDeviceListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Device> deviceQuery = appDbContext.Devices;
            if (!string.IsNullOrWhiteSpace(request.searchTerm))
            {
                deviceQuery = deviceQuery.Where(p =>
                  p.Name.Contains(request.searchTerm) ||
                  ((string)p.Owner).Contains(request.searchTerm) ||
                  ((string)p.Labels).Contains(request.searchTerm)
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
            var products = await PagedList<Device>.CreateAsync(
              deviceQuery,
              request.page,
              request.pageSize);

            return products;

        }

        private static Expression<Func<Device, object>> GetSortProperty(GetDeviceListQuery request) =>
        request.sortColumn?.ToLower() switch
        {
            "CreatedAt" => product => product.CreatedAt,
            "ModifiedAt" => product => product.ModifiedAt,
            "Name" => product => product.Name,
            "Labels" => product => product.Labels,
            "Owner" => product => product.Owner,
            _ => product => product.Id
        };
        //=> await appDbContext.Devices.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);

    }
}
