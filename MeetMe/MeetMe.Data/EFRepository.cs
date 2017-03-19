using System.Data.Entity;
using System.Linq;
using Bytes2you.Validation;
using MeetMe.Data.Contracts;

namespace MeetMe.Data
{
    public class EFRepository<T> : IEFRepository<T>
        where T : class
    {
        private readonly IMeetMeDbContext context;
        private readonly IDbSet<T> set;

        public EFRepository(IMeetMeDbContext context)
        {
            Guard.WhenArgument(context, "DbContext").IsNull().Throw();

            this.context = context;
            this.set = this.context.Set<T>();
        }

        public IQueryable<T> All
        {
            get { return this.set; }
        }

        public void Add(T entity)
        {
            Guard.WhenArgument(entity, "Entity").IsNull().Throw();

            var entry = this.context.GetState(entity);
            entry.State = EntityState.Added;
        }

        public T GetById(int id)
        {
            Guard.WhenArgument(id, "Id").IsLessThan(0).Throw();

            var record = this.set.Find(id);
            return record;
        }

        public T GetById(string id)
        {
            Guard.WhenArgument(id, "Id").IsNull().Throw();

            var record = this.set.Find(id);
            return record;
        }

        public void Delete(T entity)
        {
            Guard.WhenArgument(entity, "Entity").IsNull().Throw();

            var entry = this.context.GetState(entity);
            entry.State = EntityState.Deleted;
        }

        public void Update(T entity)
        {
            Guard.WhenArgument(entity, "Entity").IsNull().Throw();

            var entry = this.context.GetState(entity);
            entry.State = EntityState.Modified;
        }
    }
}
