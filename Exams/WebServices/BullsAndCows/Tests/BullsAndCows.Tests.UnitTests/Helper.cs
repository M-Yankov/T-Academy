namespace BullsAndCows.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BullsAndCows.Common;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Contracts;
    using Moq;

    public class Helper
    {
        private static IList<Player> players;
        private static IList<Game> games;

        public static IScoreService GetScoreMockService()
        {
            players = new List<Player>()
            {
                new Player() { UserName = "PHP@mail.bg", Email = "PHP@mail.bg", Id = "1415", Wins = 2, Losses = 2, Rank = 230 },
                new Player() { UserName = "JavaScript@mail.bg", Email = "JavaScript@mail.bg", Id = "1634", Wins = 1, Losses = 5, Rank = 175 },
                new Player() { UserName = "Y8gamesOAuth@tkey.com", Email = "Y8gamesOAuth@tkey.com", Id = "345", Wins = 4, Losses = 0, Rank = 400 },
                new Player() { UserName = "Losho@hmail.bg", Email = "Losho@hmail.bg", Id = "921", Wins = 1, Losses = 2, Rank = 130 },
                new Player() { UserName = "Cats@mail.bg", Email = "Cats@mail.bg", Id = "77455", Wins = 6, Losses = 1, Rank = 615 },
                new Player() { UserName = "ShrialP@mail.com", Email = "ShrialP@mail.co", Id = "35", Wins = 3, Losses = 1, Rank = 315 },
                new Player() { UserName = "Gerianan@gmail.com", Email = "Gerianan@gmail.com", Id = "125", Wins = 2, Losses = 4, Rank = 260 },
                new Player() { UserName = "Pesho@mail.bg", Email = "Pesho@mail.bg", Id = "1", Wins = 2, Losses = 2, Rank = 230 },
                new Player() { UserName = "Georgi@mail.bg", Email = "Georgi@mail.bg", Id = "8", Wins = 1, Losses = 4, Rank = 160 },
                new Player() { UserName = "Y8games@tkey.com", Email = "Y8games@tkey.com", Id = "13", Wins = 4, Losses = 0, Rank = 400 },
                new Player() { UserName = "Gosho@hmail.bg", Email = "Gosho@hmail.bg", Id = "21", Wins = 5, Losses = 2, Rank = 530 },
                new Player() { UserName = "KOceto79@mail.bg", Email = "KOceto79@mail.bg", Id = "125", Wins = 6, Losses = 1, Rank = 615 },
                new Player() { UserName = "MarialP@mail.com", Email = "MarialP@mail.com", Id = "83", Wins = 2, Losses = 6, Rank = 290 },
                new Player() { UserName = "Geri@gmail.com", Email = "Geri@gmail.com", Id = "71", Wins = 2, Losses = 2, Rank = 230 },
            };

            var fakedservice = new Mock<IScoreService>();
            fakedservice.Setup(s => s.GetTopPlayers())
                        .Returns(players.OrderByDescending(x => x.Rank)
                                        .ThenBy(x => x.UserName)
                                        .Take(GlobalConstants.EntitiesPerPage)
                                        .AsQueryable());

            return fakedservice.Object;
        }

        public static IGameService GetGameMockService()
        {
            games = new List<Game>()
            {
                new Game()
                {
                    Id = 1,
                    Name = "My test Game",
                    GameState = GameState.WaitingForOpponent,
                    DateCreated = new DateTime(2015, 12, 3),
                    RedPlayerGuessNumber = "4123",
                    RedPlayer = new Player() { UserName = "Cats@mail.bg", Email = "Cats@mail.bg", Id = "77455", Wins = 6, Losses = 1, Rank = 615 },
                    BluePlayer = null,
                },
                new Game()
                {
                    Id = 134,
                    Name = "My test Game",
                    DateCreated = new DateTime(2015, 2, 23),
                    GameState = GameState.RedPlayerTurn,
                    RedPlayerGuessNumber = "6891",
                    BluePlayerGuessNumber = "9182",
                    RedPlayer = new Player() { UserName = "Geri@gmail.com", Email = "Geri@gmail.com", Id = "71", Wins = 2, Losses = 2, Rank = 230 },
                    BluePlayer = new Player() { UserName = "ShrialP@mail.com", Email = "ShrialP@mail.co", Id = "35", Wins = 3, Losses = 1, Rank = 315 },
                },
                new Game()
                {
                    Id = 512,
                    Name = "My test Game",
                    GameState = GameState.WaitingForOpponent,
                    DateCreated = new DateTime(2005, 2, 3),
                    RedPlayerGuessNumber = "1235",
                    BluePlayer = null,
                    RedPlayer = new Player() { UserName = "Pesho@mail.bg", Email = "Pesho@mail.bg", Id = "1", Wins = 2, Losses = 2, Rank = 230 },
                },
                new Game()
                {
                    Id = 15,
                    Name = "My test Game",
                    GameState = GameState.Finished,
                    DateCreated = new DateTime(2011, 11, 3),
                    RedPlayerGuessNumber = "9021",
                    BluePlayerGuessNumber = "9612",
                    RedPlayer = new Player() { UserName = "Cats@mail.bg", Email = "Cats@mail.bg", Id = "77455", Wins = 6, Losses = 1, Rank = 615 },
                    BluePlayer = new Player() { UserName = "ShrialP@mail.com", Email = "ShrialP@mail.co", Id = "35", Wins = 3, Losses = 1, Rank = 315 },
                }
            };

            var fakedService = new Mock<IGameService>();
            fakedService.Setup(x => x.GetAllGames(It.IsAny<int>()))
                        .Returns(games.OrderBy(g => g.GameState)
                                      .ThenBy(g => g.Name)
                                      .ThenBy(g => g.DateCreated)
                                      .ThenBy(g => g.RedPlayer.UserName)
                                      .Skip(It.IsAny<int>() * GlobalConstants.EntitiesPerPage)
                                      .Take(GlobalConstants.EntitiesPerPage)
                                      .AsQueryable());

            return fakedService.Object;
        }

        public static IGuessService GetGuessMockService()
        {
            return new Mock<IGuessService>().Object;
        }
    }
}