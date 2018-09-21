using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Paulo.Web.Startup))]
namespace Paulo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
