using Microsoft.AspNetCore.Identity;

namespace CIV.Entities
{
    public class Player: IdentityUser
    {
        public Player(string userName)
            : base(userName)
        {

        }
    }
}
