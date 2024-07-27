using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SharedApp3.Startup))]

namespace SharedApp3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
