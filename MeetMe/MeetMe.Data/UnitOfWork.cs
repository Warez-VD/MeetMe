using Bytes2you.Validation;
using MeetMe.Data.Contracts;

namespace MeetMe.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMeetMeDbContext dbContext;

        public UnitOfWork(IMeetMeDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "DbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
