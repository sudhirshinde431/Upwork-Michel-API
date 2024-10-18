using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WebAPI.Fillters
{
    public class AzureAdTokenValidationHandler : AuthenticationHandler<JwtBearerOptions>
    {
        private readonly ITokenValidationService _tokenValidationService;
        public AzureAdTokenValidationHandler(
            IOptionsMonitor<JwtBearerOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            ITokenValidationService tokenValidationService) : base(options, logger, encoder, clock)
        {
            _tokenValidationService = tokenValidationService ?? throw new ArgumentNullException(nameof(tokenValidationService));
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var token = await _tokenValidationService.GetTokenAsync(Context.Request);
                var principal = _tokenValidationService.ValidateToken(token);
                if (principal != null)
                {
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Invalid token.");
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex);
            }
        }
    }


   
public interface ITokenValidationService
    {
        Task<string> GetTokenAsync(HttpRequest request);
        ClaimsPrincipal ValidateToken(string token);
    }
}
