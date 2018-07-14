using CIV.DataAccess;
using CIV.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIV.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Player> _userManager;

        public GameService(
            IUnitOfWork unitOfWork, 
            UserManager<Player> userManager)
        {
            _gameRepository = unitOfWork.GetRepository<IGameRepository, Game>();
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Guid> AddGame(string name, string creator)
        {
            var player = await _userManager.FindByNameAsync(creator);
            var game = Game.Create(name, player);
            await _gameRepository.AddAsync(game);
            await _unitOfWork.SaveChangesAsync();
            return game.Id;
        }

        public async Task<bool> IsGameCreator(string name, string userName)
        {
            var game = await _gameRepository.GetByNameAsync(name);
            return game.Creator.UserName == userName;
        }

        public async Task<string> GetGameCreator(string name)
        {
            var game = await _gameRepository.GetByNameAsync(name);
            if(game == null)
            {
                throw new ArgumentException("Game not found", nameof(name));
            }
            return game?.Creator?.UserName;
        }

        public async Task<string> AddPlayer(string gameName, string userName)
        {
            var player = await _userManager.FindByNameAsync(userName);
            var game = await _gameRepository.GetByNameAsync(gameName);
            game.AddPlayer(player);
            await _unitOfWork.SaveChangesAsync();
            return player.Id;
        }

        public async Task<IEnumerable<string>> GetPlayerNames(string name)
        {
            var game = await _gameRepository.GetByNameAsync(name);
            if (game == null)
            {
                return Enumerable.Empty<string>();
            }
            return game.PlayerUserNames;
        }

        public async Task<bool> HasPlayer(string gameName, string userName)
        {
            var game = await _gameRepository.GetByNameAsync(gameName);
            return game.HasPlayer(userName);
        }
    }
}
