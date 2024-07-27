using Microsoft.Owin.Security.Cookies;
using System;
using System.Net.PeerToPeer;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SharedApp3.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validate()
        {
            var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Role, "User")
                };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

            HttpContext.GetOwinContext().Authentication.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
            {
                IsPersistent = false,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
            }, identity);

            return RedirectToAction("Index", "Home");
        }

    }
}