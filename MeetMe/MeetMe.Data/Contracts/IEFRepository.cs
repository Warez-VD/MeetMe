using System.Linq;

namespace MeetMe.Data.Contracts
{
    public interface IEFRepository<T>
    {
        IQueryable<T> All { get; }

        void Add(T entity);

        T GetById(int id);

        T GetById(string id);

        void Update(T entity);

        void Delete(T entity);
    }
}
