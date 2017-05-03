using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace lms.apis.core.Securities
{
    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (userName != ConfigurationManager.AppSettings["Basic.Authentication.Username"].ToString() ||
                password != ConfigurationManager.AppSettings["Basic.Authentication.Password"].ToString())
            {
                return null;
            }

            var nameClaim = new Claim(ClaimTypes.Name, userName);
            var claims = new List<Claim> { nameClaim };
            var identity = new ClaimsIdentity(claims, "Basic");
            var principal = new ClaimsPrincipal(identity);

            return principal;
        }
    }
}