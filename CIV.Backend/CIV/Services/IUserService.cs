using System.Threading.Tasks;
using CIV.Entities;

namespace CIV.Services
{
    public interface IUserService
    {
        Task CreateAsync(string userName);
        Task<Player> GetAsync(string userName);
        Task<bool> ExistsAsync(string userName);
    }
}