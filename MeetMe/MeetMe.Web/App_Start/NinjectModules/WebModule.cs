using MeetMe.Web.Helpers;
using MeetMe.Web.Helpers.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MeetMe.Web.App_Start.NinjectModules
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IIdentityHelper>().To<IdentityHelper>().InRequestScope();
        }
    }
}