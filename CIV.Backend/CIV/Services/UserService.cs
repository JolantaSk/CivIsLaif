using CIV.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace CIV.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Player> _userManager;

        public UserService(UserManager<Player> userManager)
        {
            _userManager = userManager;
        }

        public async Task CreateAsync(string userName)
        {
            if(await ExistsAsync(userName))
            {
                throw new InvalidOperationException("User already exists");
            }
            await _userManager.CreateAsync(new Player(userName));
        }

        public async Task<Player> GetAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<bool> ExistsAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName) != null;
        }
    }
}
