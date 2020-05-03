using Microsoft.AspNetCore.Authentication.Cookies;
using SimpleTaskManager.Data.Entities;
using SimpleTaskManager.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Principal;

namespace SimpleTaskManager.Web.Common
{
        
    public class LoginHelper
    {
        public static ClaimsPrincipal GetLocalPrincipal(User user)
        {
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
