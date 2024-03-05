using System.Linq.Expressions;

namespace UserManageAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);

        void save();
    }
}
