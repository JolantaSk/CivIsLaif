using CIV.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIV.Services
{
    public interface IGameService
    {
        Task<Guid> AddGame(string name, string creator);
        Task<string> AddPlayer(string gameName, string userName);
        Task<string> GetGameCreator(string name);
        Task<IEnumerable<string>> GetPlayerNames(string name);
        Task<bool> HasPlayer(string gameName, string userName);
        Task<bool> IsGameCreator(string name, string userName);
        Task FinishTurn(string name, string userName);
    }
}