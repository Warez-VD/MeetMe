using MeetMe.Data;
using MeetMe.Data.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MeetMe.Web.App_Start.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMeetMeDbContext>().To<MeetMeDbContext>().InRequestScope();
        }
    }
}