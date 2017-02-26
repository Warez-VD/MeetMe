using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetMe.Web.Startup))]
namespace MeetMe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
