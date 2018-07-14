using CIV.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CIV.DataAccess
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(CivDbContext context) 
            : base(context)
        {
        }

        public Task<Game> GetByNameAsync(string name)
        {
            return Context.Set<Game>()
                .Where(g => g.Name == name)
                .ToAsyncEnumerable()
                .SingleOrDefault();
        }
    }

    public class PlayerRepository : Repository<Player>
    {
        public PlayerRepository(CivDbContext context) 
            : base(context)
        {
        }
    }
}
