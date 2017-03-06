using System.Data.Entity.Infrastructure;

namespace MeetMe.Data.Contracts
{
    public interface IStateFactory
    {
        IEntryState<T> CreateState<T>(DbEntityEntry<T> entry) where T : class;
    }
}
