using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MeetMe.Data.Contracts
{
    public interface IRepository<T>
    {
        void Add(T entity);

        T GetById(int id);

        T GetById(string id);

        IEnumerable<T> All();

        IEnumerable<T> All(Expression<Func<T, bool>> filter);

        IEnumerable<T> All<K>(Expression<Func<T, bool>> filter, Expression<Func<T, K>> sort, bool isAscending);

        void Update(T entity);

        void Delete(T entity);
    }
}
