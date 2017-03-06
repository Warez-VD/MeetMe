using System.Data.Entity;

namespace MeetMe.Data.Contracts
{
    public interface IEntryState<T>
    {
        EntityState State { get; set; }
    }
}
