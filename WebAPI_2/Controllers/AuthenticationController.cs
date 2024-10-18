using ApplicationLayer.Queries.AuthenticationQuery;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_2.Controllers
{

    [Route("api/Authentication")]
    [ApiController]
   // [EnableCors("AllowAll")]
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
