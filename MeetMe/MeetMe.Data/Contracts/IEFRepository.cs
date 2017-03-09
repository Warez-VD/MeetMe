using System.Linq;

namespace MeetMe.Data.Contracts
{
    public interface IEFRepository<T>
    {
        void Add(T entity);

        T GetById(int id);

        T GetById(string id);

        IQueryable<T> All { get; }

        void Update(T entity);

        void Delete(T entity);
    }
}
