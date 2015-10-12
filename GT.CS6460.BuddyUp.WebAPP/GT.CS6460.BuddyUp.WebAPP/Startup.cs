using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GT.CS6460.BuddyUp.WebAPP.Startup))]
namespace GT.CS6460.BuddyUp.WebAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
