using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace InfrastructureLayer.Handlers.EmployeeHandler
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<Employee>>
    {
        private readonly AppDbContext appDbContext;
        public GetEmployeeListHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
            => await appDbContext.Employees.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);

    }
}
