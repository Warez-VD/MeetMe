using Ninject.Extensions.Conventions;
using Ninject.Modules;
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

            this.Bind(x =>
            {
                x.FromAssembliesMatching("MeetMe.Services.dll")
                .Select(t => t.Name.Contains("Factory"))
                .BindToFactory()
                .Configure(s => s.InRequestScope());
            });
        }
    }
}