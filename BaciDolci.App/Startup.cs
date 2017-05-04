using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaciDolci.App.Startup))]
namespace BaciDolci.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
