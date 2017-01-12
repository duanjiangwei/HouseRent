using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HouseWeb.Startup))]
namespace HouseWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
