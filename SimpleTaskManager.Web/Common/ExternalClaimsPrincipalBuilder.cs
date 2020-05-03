using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SimpleTaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleTaskManager.Web.Common
{
    public class ExternalClaimsPrincipalBuilder
    {
        private AuthenticateResult _authResult;
        private string _claimType;        
        private Func<string, User> _userGetter;
        public ExternalClaimsPrincipalBuilder()
        {            
        }

        public ExternalClaimsPrincipalBuilder AddAuthenticationResult(AuthenticateResult result)
        {
            _authResult = result;
            return this;
        }

        public ExternalClaimsPrincipalBuilder AddClaimsType(string claimType)
        {
            _claimType = claimType;
            return this;
        }

        public ExternalClaimsPrincipalBuilder AddUser(Func<string, User> getUser)
        {
            _userGetter = getUser;
            return this;
        }

        public ClaimsPrincipal Build()
        {
            var user = _userGetter(_authResult.Principal.Claims.FirstOrDefault(x => x.Type == _claimType).Value);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("FavoriteColor", user.FavoriteColor)
            };

            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            return principal;
        }

    }
}
