using CIV.DataAccess;
using CIV.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CIV
{
    public static class DependecyServiceCollectionExtensions
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IUnitOfWork>(s => new UnitOfWork(s.GetService<CivDbContext>(), t => s.GetService(t)));
        }
    }
}
