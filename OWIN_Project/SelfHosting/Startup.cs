using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OWIN_Project.Startup))]
namespace OWIN_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
					// New code:
					app.Run(context =>
					{
						context.Response.ContentType = "text/plain";
						return context.Response.WriteAsync("Hello, world.");
					});
        }
    }
}
