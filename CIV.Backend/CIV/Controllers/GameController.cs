using Microsoft.AspNetCore.Mvc;

namespace CIV.Controllers
{
    [Route("api/[controller]")]
    public class GameController: Controller
    {
        public void Post(CreateGameModel model)
        {
            GameStore.AddGame(model.Name);
        }
    }

    public class CreateGameModel
    {
        public string Name { get; set; }
    }
}