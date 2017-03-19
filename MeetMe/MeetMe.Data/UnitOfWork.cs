using Bytes2you.Validation;
using MeetMe.Data.Contracts;

namespace MeetMe.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMeetMeDbContext context;

        public UnitOfWork(IMeetMeDbContext context)
        {
            Guard.WhenArgument(context, "DbContext").IsNull().Throw();

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
