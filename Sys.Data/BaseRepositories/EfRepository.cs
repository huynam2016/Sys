using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Sys.Data.BaseRepositories
{
    public class EfRepository<T> : IEfRepository<T> where T : class
    {
        private AppDbContext _context;
        private IDbSet<T> dbEntity;
        public EfRepository()
        {
            _context = new AppDbContext();
            dbEntity = _context.Set<T>();
        }
        public virtual IQueryable<T> GetAll()
        {
            return dbEntity.ToList().AsQueryable();
        }
        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbEntity;
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.AsQueryable();
        }
        public virtual int Count()
        {
            return dbEntity.Count();
        }
        public virtual T GetSingle(int id)
        {
            return dbEntity.Find(id);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return dbEntity.FirstOrDefault(predicate);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbEntity;
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.Where(predicate).FirstOrDefault();
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public virtual void Add(T entity)
        {
            dbEntity.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

      
        public virtual void Save()
        {
            _context.SaveChanges();
        }

       
    }
}
