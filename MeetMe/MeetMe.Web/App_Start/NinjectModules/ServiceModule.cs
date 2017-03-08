using Ninject.Modules;
using Ninject.Extensions.Conventions;
using MeetMe.Services.Contracts;
using Ninject.Extensions.Factory;
using Ninject.Web.Common;

namespace MeetMe.Web.App_Start.NinjectModules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x =>
            {
                x.FromAssembliesMatching("MeetMe.Services.dll")
                .SelectAllClasses()
                .BindDefaultInterfaces()
                .Configure(s => s.InRequestScope());
            });

            this.Bind<IAspIdentityUserFactory>().ToFactory().InRequestScope();
            this.Bind<ICustomUserFactory>().ToFactory().InRequestScope();
            this.Bind<IProfileLogoFactory>().ToFactory().InRequestScope();
        }
    }
}