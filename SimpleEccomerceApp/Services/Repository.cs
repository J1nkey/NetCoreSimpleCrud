using SimpleEcommerceApp.Data;
using System.Linq.Expressions;

namespace SimpleEcommerceApp.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _db;
        protected readonly ApplicationDapperContext _dapperContext;

        public Repository(ApplicationDbContext db,
            ApplicationDapperContext dapperContext)
        {
            _db = db;
            _dapperContext = dapperContext;
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _db.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.Set<T>().RemoveRange(entities);
        }
    }
}
