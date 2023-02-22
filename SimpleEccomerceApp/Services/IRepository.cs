using System.Linq.Expressions;

namespace SimpleEcommerceApp.Services
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
    }
}
