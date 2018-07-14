using System;
using System.Threading.Tasks;

namespace CIV.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CivDbContext _context;
        private readonly Func<Type, object> _repositoryFactory;

        public UnitOfWork(CivDbContext context, Func<Type, object> repositoryFactory)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity: class
        {
            if (!(_repositoryFactory(typeof(IRepository<TEntity>)) is IRepository<TEntity> repository))
            {
                throw new ArgumentException("Repository could not be created");
            }
            return repository;
        }

        public T GetRepository<T, TEntity>()
            where T : class, IRepository<TEntity>
            where TEntity: class
        {
            if (!(_repositoryFactory(typeof(T)) is T repository))
            {
                throw new ArgumentException("Repository could not be created");
            }
            return repository;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
