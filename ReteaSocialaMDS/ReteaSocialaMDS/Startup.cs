using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReteaSocialaMDS.Startup))]
namespace ReteaSocialaMDS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Cookie-urile o sa retina user-ul logat
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);



            //activeaza SignalR
            app.MapSignalR();

            //toate huburile o sa ceara autentificare in mod implicit
            GlobalHost.HubPipeline.RequireAuthentication();

            ConfigureAuth(app);
        }
    }
}
