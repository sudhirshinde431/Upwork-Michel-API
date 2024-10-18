using ApplicationLayer.Queries.AuthenticationQuery;
using ApplicationLayer.Queries.EmployeeQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/Authentication")]
    [ApiController]  
    [EnableCors("_myAllowSpecificOrigins")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IMediator mediator;
        public AuthenticationController(IMediator mediator) =>
            this.mediator = mediator;

       
        [HttpPost("ValidateUser", Name = "ValidateUser")]
        public async Task<IActionResult> ValidateUser(string userName
            ) =>
            Ok(await mediator.Send(new GetAuthenticationQuery
            {
                userName = userName
            }));
    }
}
