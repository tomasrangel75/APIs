using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OWIN_Project.Startup))]
namespace OWIN_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
