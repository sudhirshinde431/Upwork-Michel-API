using ApplicationLayer.Commands;
using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_2.Controllers
{
    [Route("api/Device")]
    [ApiController]
    [Authorize]
  //  [EnableCors("_myAllowSpecificOrigins")]
  //  [DisableCors]
    public class DeviceController : ControllerBase
    {

        private readonly IMediator mediator;
        public DeviceController(IMediator mediator) =>
            this.mediator = mediator;

        //[DisableCors]
        [HttpPost("Get", Name = "Get")]
        public async Task<IActionResult> Get(
             string? searchTerm,
          string? sortColumn,
          string? sortOrder,
          int page,
          int pageSize
            ) =>
            Ok(await mediator.Send(new GetDeviceListQuery
            {

                searchTerm = searchTerm,
                sortColumn = sortColumn,
                sortOrder = sortOrder,
                page = page,
                pageSize = pageSize
            }));


    }
}
