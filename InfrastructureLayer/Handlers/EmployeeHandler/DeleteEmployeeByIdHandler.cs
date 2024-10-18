using ApplicationLayer.Commands;
using ApplicationLayer.DTOs;
using InfrastructureLayer.Data;
using MediatR;

namespace InfrastructureLayer.Handlers.EmployeeHandler
{
    public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeByIdCommand, ServiceResponse>
    {
        private readonly AppDbContext appDbContext;
        public DeleteEmployeeByIdHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            var employee = await appDbContext.Employees.FindAsync(request.Id);
            if (employee == null)
                return new ServiceResponse(false, "User not found");

            appDbContext.Employees.Remove(employee);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }
    }
}
