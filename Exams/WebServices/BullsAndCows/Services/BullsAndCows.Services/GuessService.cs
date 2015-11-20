namespace BullsAndCows.Services
{
    using System;
    using BullsAndCows.Common;
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Contracts;

    public class GuessService : IGuessService
    {
        private IBullsAndCowsSystem system;
        private INotificationService notifySystem;

        public GuessService(IBullsAndCowsSystem bullsAndCowsSystem, INotificationService notificationSystem)
        {
            this.notifySystem = notificationSystem;
            this.system = bullsAndCowsSystem;
        }

        public Guess MakeGuess(string guessNumber, string aginast, string userId, int gameId)
        {
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < guessNumber.Length; i++)
            {
                if (aginast.Contains(guessNumber[i].ToString()))
                {
                    cows++;
                    if (guessNumber[i] == aginast[i])
                    {
                        bulls++;
                    }
                }
            }

            Game game = this.system.Games.GetById(gameId);
            Player currentPlayer = this.system.Players.GetById(userId);
            Player otherPlayer = game.RedPlayerId == userId ? game.BluePlayer : game.RedPlayer;

            if (bulls == GlobalConstants.NumberLength)
            {
                currentPlayer.Wins++;
                otherPlayer.Losses++;
                currentPlayer.Rank = this.CalculateRank(currentPlayer.Wins, currentPlayer.Losses);
                otherPlayer.Rank = this.CalculateRank(otherPlayer.Wins, otherPlayer.Losses);
                this.system.Players.Update(currentPlayer);
                this.system.Players.Update(otherPlayer);
                this.system.SaveChanges();

                this.notifySystem.SendNotificationToUser(
                    currentPlayer.Id,
                    string.Format(GlobalNotificationMessages.WinMessageFormat, otherPlayer.UserName, game.Name),
                    MessageState.Unread,
                    MessageType.GameWon,
                    game.Id);

                this.notifySystem.SendNotificationToUser(
                    otherPlayer.Id,
                    string.Format(GlobalNotificationMessages.LoseMessageFormat, currentPlayer.UserName, game.Name),
                    MessageState.Unread,
                    MessageType.GameLost,
                    game.Id);

                game.GameState = GameState.Finished;
            }
            else
            {
                this.notifySystem.SendNotificationToUser(
                    otherPlayer.Id,
                    string.Format(GlobalNotificationMessages.YourTurnMessageFormat, game.Name),
                    MessageState.Unread,
                    MessageType.YourTurn,
                    game.Id);

                game.GameState = game.GameState == GameState.RedPlayerTurn ? GameState.BluePlayerTurn : GameState.RedPlayerTurn;
            }

            this.system.Games.Update(game);
            this.system.Games.SaveChanges(); // Todo: try without save changes

            var newGuess = new Guess()
            {
                BullsCount = bulls,
                CowsCount = cows,
                Number = guessNumber,
                UserId = currentPlayer.Id,
                DateMade = DateTime.Now,
                GameId = gameId
            };

            this.system.Guesses.Add(newGuess);
            this.system.Guesses.SaveChanges();

            return this.system.Guesses.GetById(newGuess.Id);
        }

        public Guess GuessById(int id)
        {
            return this.system.Guesses.GetById(id);
        }

        private int CalculateRank(int playerWins, int playerLosses)
        {
            return (GlobalConstants.NumberForCalulateWins * playerWins) + (GlobalConstants.NumberForCalulateLoses * playerLosses);
        }
    }
}
