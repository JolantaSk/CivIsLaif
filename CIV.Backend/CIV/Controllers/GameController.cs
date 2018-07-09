using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CIV.Controllers
{
    [Route("api/[controller]")]
    public class GameController: Controller
    {
        private readonly IHubContext<GameHub> _gameHubContext;

        public GameController(IHubContext<GameHub> gameHubContext)
        {
            _gameHubContext = gameHubContext;
        }

        public void Post([FromBody] CreateGameModel model)
        {
            GameStore.AddGame(model.Name, model.Creator);
        }

        [HttpGet("{name}/creator")]
        public object GetCreator(string name)
        {
            return new { username = GameStore.GetGameCreator(name) };
        }
    }

    public class CreateGameModel
    {
        public string Name { get; set; }
        public string Creator { get; set; }
    }
}