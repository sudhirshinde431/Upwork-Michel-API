using ApplicationLayer.DTOs;
using MediatR;
namespace ApplicationLayer.Commands
{
    public class DeleteEmployeeByIdCommand : IRequest<ServiceResponse>
    {
        public int Id { get; set; }
    }
}
