using CIV.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CIV
{
    [Authorize(JwtBearerDefaults.AuthenticationScheme)]
    public class GameHub: Hub
    {
        private readonly IAuthorizationService _authorizationService;

        public GameHub(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task Join(string gameName)
        {
            var connectionId = Context.ConnectionId;
            var username = Context.UserIdentifier;
            if(GameStore.GetGameCreator(gameName) != username)
                GameStore.AddPlayer(gameName, username);
            await Groups.AddToGroupAsync(connectionId, gameName);
            await Clients.OthersInGroup(gameName)
                .SendCoreAsync("PlayerJoined", new[] { username });
        }

        public async Task Start(string gameName)
        {
            var gameCreator = GameStore.GetGameCreator(gameName);
            var result = await _authorizationService.AuthorizeAsync(Context.User, gameCreator, new GameCreatorRequirement());
            if (result.Succeeded)
            {
                await Clients.Group(gameName)
                    .SendAsync("GameStarted");
            }
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
