using MeetMe.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MeetMe.Data.Contracts
{
    public interface IMeetMeDbContext
    {
        int SaveChanges();

        IDbSet<User> CustomUsers { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IEntryState<T> GetState<T>(T entity) where T : class;
    }
}
