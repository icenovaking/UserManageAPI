using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserManageAPI.Models;

namespace UserManageAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UserManageContext _db;
        internal DbSet<T> _dbSet;
        public Repository(UserManageContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        public void save()
        {
            _db.SaveChanges();
        }
    }
}
