using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rwa_mvc.Startup))]
namespace rwa_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
