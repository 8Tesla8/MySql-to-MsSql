using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppDb.Startup))]
namespace WebAppDb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
