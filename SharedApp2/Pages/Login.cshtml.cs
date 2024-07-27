using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace SharedApp2.Pages
{
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public class LoginModel(IHttpContextAccessor httpContextAccessor) : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "001"),
            new Claim(ClaimTypes.Name, "admin"),
            new Claim(ClaimTypes.Email, "admin@localhost.com"),
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await httpContextAccessor.HttpContext!
                .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties());

            return RedirectToPage("/Index");
        }
    }
}
