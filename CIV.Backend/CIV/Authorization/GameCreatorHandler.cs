using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CIV.Authorization
{
    public class GameCreatorHandler : AuthorizationHandler<GameCreatorRequirement, string>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GameCreatorRequirement requirement, string resource)
        {
            if(resource == context.User.Identity.Name)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
