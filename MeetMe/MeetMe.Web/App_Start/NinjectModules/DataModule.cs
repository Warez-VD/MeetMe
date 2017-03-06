using MeetMe.Data;
using MeetMe.Data.Contracts;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MeetMe.Web.App_Start.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMeetMeDbContext>().To<MeetMeDbContext>().InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();
            this.Bind<IStateFactory>().ToFactory().InRequestScope();
            this.Bind(typeof(IEntryState<>)).To(typeof(EntryState<>)).InRequestScope();
        }
    }
}