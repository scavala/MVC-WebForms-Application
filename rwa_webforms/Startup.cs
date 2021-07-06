using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rwa_webforms.Startup))]
namespace rwa_webforms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
