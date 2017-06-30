using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArchExample.UI.MVC.Startup))]
namespace ArchExample.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
