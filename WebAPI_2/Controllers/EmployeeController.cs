using ApplicationLayer.Commands;
using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;
        public EmployeeController( IMediator mediator) => this.mediator = mediator;
        
        [HttpGet]
        public async Task<IActionResult> Get() => 
            Ok(await mediator.Send(new GetDeviceListQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await mediator.Send(new GetEmployeeByIdQuery { Id = id}));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employeeDto) => 
            Ok(await mediator.Send(new CreateEmployeeCommand { Employee = employeeDto }));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employeeDto)
            => Ok(await mediator.Send(new UpdateEmployeeCommand { Employee = employeeDto }));

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
        Ok(await mediator.Send(new DeleteEmployeeByIdCommand { Id = id}));
    }
}
