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
            this.Bind<IPublicationFactory>().ToFactory().InRequestScope();
            this.Bind<IStatisticFactory>().ToFactory().InRequestScope();
            this.Bind<IPublicationImageFactory>().ToFactory().InRequestScope();
            this.Bind<ICommentFactory>().ToFactory().InRequestScope();
            this.Bind<IUserFriendFactory>().ToFactory().InRequestScope();
            this.Bind<INotificationFactory>().ToFactory().InRequestScope();
        }
    }
}