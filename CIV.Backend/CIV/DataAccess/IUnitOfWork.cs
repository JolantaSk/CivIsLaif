using System.Threading.Tasks;

namespace CIV.DataAccess
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;
        T GetRepository<T, TEntity>()
            where T : class, IRepository<TEntity>
            where TEntity : class;
    }
}