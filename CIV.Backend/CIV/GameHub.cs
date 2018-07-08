using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CIV
{
    [Authorize]
    public class GameHub: Hub
    {
        public GameHub()
        {
            GameStore.Games.Subscribe(async gameName => {
                await Clients.All.SendAsync("GameCreated", gameName);
            });
        }

        public async Task Join(string gameName)
        {
            var connectionId = Context.ConnectionId;
            var username = Context.User.Identity.Name;
            GameStore.AddPlayer(gameName, username);
            await Groups.AddToGroupAsync(connectionId, gameName);
            await Clients.GroupExcept(gameName, new[] { connectionId })
                .SendCoreAsync("PlayerJoined", new[] { username });
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
