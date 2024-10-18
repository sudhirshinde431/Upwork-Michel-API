using DomainLayer.Entities;
using MediatR;
namespace ApplicationLayer.Queries.EmployeeQuery
{
    public class GetDeviceListQuery : IRequest<PagedList<Device>>{
        public string? searchTerm { get; set; }
        public string? sortColumn { get; set; }
        public string? sortOrder { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }
}
