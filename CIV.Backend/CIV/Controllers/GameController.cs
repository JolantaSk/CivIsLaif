using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace CIV.Controllers
{
    [Route("api/[controller]")]
    public class GameController: Controller
    {
        public void Post([FromBody]string name)
        {
            GameStore.AddGame(name);
        }
    }
}