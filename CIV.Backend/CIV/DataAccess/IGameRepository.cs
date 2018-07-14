using System.Threading.Tasks;
using CIV.Entities;

namespace CIV.DataAccess
{
    public interface IGameRepository: IRepository<Game>
    {
        Task<Game> GetByNameAsync(string name);
    }
}