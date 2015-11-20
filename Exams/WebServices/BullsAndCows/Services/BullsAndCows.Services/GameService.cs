namespace BullsAndCows.Services
{
    using System;
    using System.Linq;
    using BullsAndCows.Common;
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Contracts;

    public class GameService : IGameService
    {
        private IBullsAndCowsSystem system;
        private NotificationService notifySystem;

        public GameService(IBullsAndCowsSystem bullsAndCowsSystem, NotificationService notifyService)
        {
            this.system = bullsAndCowsSystem;
            this.notifySystem = notifyService;
        }

        public IQueryable<Game> GetAllGames(int page)
        {
            return this.system.Games
                       .All()
                       .OrderBy(g => g.GameState)
                       .ThenBy(g => g.Name)
                       .ThenBy(g => g.DateCreated)
                       .ThenBy(g => g.RedPlayer.UserName)
                       .Skip(page * GlobalConstants.EntitiesPerPage)
                       .Take(GlobalConstants.EntitiesPerPage);
        }

        public Game GetGameDetails(int id)
        {
            return this.system.Games.GetById(id);
        }

        public Game CreateNewGame(string gameName, string firstPlayerGuessnumber, string playerId)
        {
            Player current = this.system.Players.GetById(playerId);
            this.system.Players.Attach(current);

            Game game = new Game
            {
                GameState = GameState.WaitingForOpponent,
                Name = gameName,
                RedPlayerGuessNumber = firstPlayerGuessnumber,
                RedPlayerId = current.Id,
                DateCreated = DateTime.Now
            };

            this.system.Games.Add(game);
            this.system.Games.SaveChanges();

            return game;
        }
        
        public void JoinGame(Game game, string bluePlayerId, string bluePlayerNumber, string bluePlayerUsername)
        {
            game.BluePlayerId = bluePlayerId;
            game.BluePlayerGuessNumber = bluePlayerNumber;
            game.GameState = GameState.RedPlayerTurn; //// Todo: random turn

            this.system.Games.Update(game);
            this.system.Games.SaveChanges();

            this.notifySystem
                .SendNotificationToUser(
                    game.RedPlayerId,
                    string.Format(GlobalNotificationMessages.JoinGameMessageFormat, bluePlayerUsername, game.Name),
                    MessageState.Unread,
                    MessageType.GameJoined,
                    game.Id);
        }
    }
}