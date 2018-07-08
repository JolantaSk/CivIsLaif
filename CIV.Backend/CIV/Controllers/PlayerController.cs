using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CIV.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController: Controller
    {
        public IEnumerable<string> Get([FromQuery]string name)
        {
            return GameStore.GetPlayerNames(name);
        }
    }
}
