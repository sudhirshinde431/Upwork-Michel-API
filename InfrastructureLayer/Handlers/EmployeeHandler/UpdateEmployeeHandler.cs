using ApplicationLayer.Commands;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using MediatR;

namespace InfrastructureLayer.Handlers.EmployeeHandler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, ServiceResponse>
    {
        private readonly AppDbContext appDbContext;

        public UpdateEmployeeHandler(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            appDbContext.Update(request.Employee);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }
    }
}
