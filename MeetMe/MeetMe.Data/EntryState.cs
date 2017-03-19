using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MeetMe.Data.Contracts;

namespace MeetMe.Data
{
    public class EntryState<T> : IEntryState<T>
        where T : class
    {
        private DbEntityEntry<T> entry;

        public EntryState(DbEntityEntry<T> entry)
        {
            this.entry = entry;
        }

        public EntityState State
        {
            get
            {
                return this.entry.State;
            }

            set
            {
                this.entry.State = value;
            }
        }
    }
}
