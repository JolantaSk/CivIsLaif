using CIV.Entities;
using Microsoft.EntityFrameworkCore;
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
                .Include(g => g.Creator)
                .Where(g => g.Name == name)
                .ToAsyncEnumerable()
                .SingleOrDefault();
        }
    }
}
