using System.Web;
using MeetMe.Web.Auth;
using MeetMe.Web.Auth.Contracts;
using Microsoft.AspNet.Identity.Owin;
using Ninject.Modules;

namespace MeetMe.Web.App_Start.NinjectModules
{
    public class AuthModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISignInManager>().ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
            this.Bind<IUserManager>().ToMethod(_ => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());
        }
    }
}