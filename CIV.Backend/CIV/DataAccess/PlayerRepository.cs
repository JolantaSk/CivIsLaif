using CIV.Entities;

namespace CIV.DataAccess
{
    public class PlayerRepository : Repository<Player>
    {
        public PlayerRepository(CivDbContext context) 
            : base(context)
        {
        }
    }
}
