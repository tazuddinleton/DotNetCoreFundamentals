using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleTaskManager.Data.Repositories;
using SimpleTaskManager.Web.Common;
using SimpleTaskManager.Web.Model;

namespace SimpleTaskManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepo;
       

        public AccountController(IUserRepository userRepo)
        {
            _userRepo = userRepo;            
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginModel() { ReturnUrl = returnUrl });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = _userRepo.GetByUsernameAndPassword(model.Username, model.Password);
            if (user == null)
                return Unauthorized();

            var authProp = new AuthenticationProperties
            {
                IsPersistent = model.RememberLogin
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                LoginHelper.GetLocalPrincipal(user),
                authProp
                );

            return LocalRedirect(model.ReturnUrl);
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LoginWithGoogle(string returnUrl = "/")
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleLoginCallback"),
                Items =
                {
                    {"returnUrl", returnUrl }
                }
            };
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleLoginCallback()
        {
            var result = await HttpContext.AuthenticateAsync(ExternalAuthenticationDefaults.AuthenticationScheme);

            var principal = 
            new ExternalClaimsPrincipalBuilder()
                .AddAuthenticationResult(result)
                .AddClaimsType(ClaimTypes.Email)
                .AddUser(email => _userRepo.GetByEmail(email))
                .Build();

            // delete temporary cookie used during google authentication
            await HttpContext.SignOutAsync(
                ExternalAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return LocalRedirect(result.Properties.Items["returnUrl"]);

        }


       


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }

    }
}