using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sys.Data.BaseRepositories
{
    public interface IEfRepository<T> where T: class
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAll();
        int Count();
        T GetSingle(int id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
