namespace BullsAndCows.Services.Contracts
{
    using System;
    using System.Linq;
    using BullsAndCows.Models;

    public interface IGameService
    {
        IQueryable<Game> GetAllGames(int page);

        Game GetGameDetails(int id);

        Game CreateNewGame(string gameName, string firstPlayerGuessnumber, string playerId);

        void JoinGame(Game game, string bluePlayerId, string bluePlayerNumber, string bluePlayerUsername);
    }
}