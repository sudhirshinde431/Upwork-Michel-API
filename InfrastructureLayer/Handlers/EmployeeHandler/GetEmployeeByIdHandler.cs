using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using MediatR;
namespace InfrastructureLayer.Handlers.EmployeeHandler
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly AppDbContext appDbContext;
        public GetEmployeeByIdHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        => await appDbContext.Employees.FindAsync(request.Id);
    }
}
