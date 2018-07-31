using CIV.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CIV.Controllers
{
    [Route("api/[controller]")]
    public class GameController: Controller
    {
        private readonly IHubContext<GameHub> _gameHubContext;
        private readonly IGameService _gameService;

        public GameController(
            IHubContext<GameHub> gameHubContext, 
            IGameService gameService)
        {
            _gameHubContext = gameHubContext;
            _gameService = gameService;
        }

        public async Task Post([FromBody] CreateGameModel model)
        {
            await _gameService.AddGame(model.Name, model.Creator);
        }

        [HttpGet("{name}/creator")]
        public async Task<object> GetCreator(string name)
        {
            return new { username = await _gameService.GetGameCreator(name) };
        }

        [HttpGet("{name}/state")]
        public object GetState(string name)
        {
            return new
            {
                turn = 1,
                phase = "Phase 1",
                currentPlayer = User.Identity.Name,
                timeElapsedInMilliseconds = 12
            };
        }

        [HttpGet("{name}/players")]
        public async Task<IEnumerable<string>> GetPlayers(string name)
        {
            return await _gameService.GetPlayerNames(name);
        }
    }
}