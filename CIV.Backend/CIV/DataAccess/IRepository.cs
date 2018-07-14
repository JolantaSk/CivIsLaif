using System.Threading.Tasks;
using CIV.Entities;

namespace CIV.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<TEntity> GetAsync<TEntity, TKey>(TKey id) where TEntity : class, IEntity<TKey>, T;
        void Remove(T entity);
    }
}