using System;
using System.IO;

using Microsoft.AspNetCore.DataProtection;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Interop;

using Owin;

namespace SharedApp3
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                LoginPath = new PathString("/Security/Login"),
                CookieName = ".Client1.PeoplesHR.SharedCookie",
                CookieDomain = ".localhost.com",
                CookiePath = "/",
                CookieHttpOnly = true,
                SlidingExpiration = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(30),
                TicketDataFormat = new AspNetTicketDataFormat(
                    new DataProtectorShim(
                        DataProtectionProvider.Create(new DirectoryInfo(@"C:\Shared.Keys"),
                        (builder) =>
                        {
                            builder.SetApplicationName("PeoplesHR");
                        })
                        .CreateProtector(
                            "Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware",
                            "Cookie",
                            "v2")))
            });
        }
    }
}