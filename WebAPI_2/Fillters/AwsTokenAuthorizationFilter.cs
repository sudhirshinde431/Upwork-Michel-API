using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Fillters
{
    public class AwsTokenAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token) || !ValidateToken(token))
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool ValidateToken(string token)
        {
            // Here you would validate the token against AWS or your logic.
            // This is a placeholder for your validation logic.

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
                return false;

            try
            {
                var jwtToken = handler.ReadJwtToken(token);
                // Perform additional validation here, such as checking claims, expiration, etc.
                return true;
            }
            catch
            {
                return false;
            }
        }


    }

}