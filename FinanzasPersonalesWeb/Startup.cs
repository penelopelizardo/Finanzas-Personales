using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinanzasPersonalesWeb.Startup))]
namespace FinanzasPersonalesWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
