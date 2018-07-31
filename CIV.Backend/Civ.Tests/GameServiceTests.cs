//using CIV.DataAccess;
//using CIV.Entities;
//using CIV.Services;
//using Microsoft.AspNetCore.Identity;
//using Moq;
//using System.Threading.Tasks;
//using Xunit;

//namespace Civ.Tests
//{
//    public class GameServiceTests
//    {
//        private Phase[] _phases = new[] { new Phase("Start of the turn", 0),
//                    new Phase("Trade", 1),
//                    new Phase("City management", 2),
//                    new Phase("Movement", 3),
//                    new Phase("Research", 4)};

//        [Fact]
//        public async Task GameService_NextTurn_MovesToNextPhaseIfPhaseSimultanious()
//        {
//            //ARRANGE
//            var gameName = "name";
//            Player creator = new Player("creator");
//            Player other = new Player("other");
//            var turnOrders = new[] { new PlayerTurnOrder(creator, 0), new PlayerTurnOrder(other, 1) };
//            var game = Game.Create(gameName, creator);

//            game.Start(turnOrders, _phases);
//            var activePhase = game.Turn;
//            var userStore = new Mock<IUserStore<Player>>();
//            var userManager = new UserManager<Player>(userStore.Object, null, null, null, null, null, null, null, null);
//            var gameRepositoryMock = new Mock<IGameRepository>();
//            gameRepositoryMock.Setup(r => r.GetByNameAsync(gameName))
//                .Returns(Task.FromResult(game));
//            var unitOfWorkMock = new Mock<IUnitOfWork>();
//            var gameService = new GameService(unitOfWorkMock.Object, userManager);

//            //ACT
//            await gameService.NextTurn(gameName);

//            //ASSERT
//            Assert.NotEqual(activePhase, game.Turn);
//        }
//    }
//}
