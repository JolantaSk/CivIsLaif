using CIV.Entities;
using System.Threading.Tasks;

namespace CIV.DataAccess
{
    public class Repository<T> : IRepository<T>
        where T: class
    {
        protected readonly CivDbContext Context;

        public Repository(CivDbContext context)
        {
            Context = context;
        }

        public Task<TEntity> GetAsync<TEntity, TKey>(TKey id)
            where TEntity: class, T, IEntity<TKey>
        {
            return Context.FindAsync<TEntity>(id);
        }

        public Task AddAsync(T entity)
        {
            return Context.AddAsync(entity);
        }

        public virtual void Remove(T entity)
        {
            Context.Remove(entity);
        }
    }
}
