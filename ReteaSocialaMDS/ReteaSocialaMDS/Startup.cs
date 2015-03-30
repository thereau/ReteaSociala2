using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReteaSocialaMDS.Startup))]
namespace ReteaSocialaMDS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
