namespace BullsAndCows.Services.Contracts
{
    using BullsAndCows.Models;

    public interface IGuessService
    {
        Guess MakeGuess(string guessNumber, string agiansTo, string userId, int gameId);

        Guess GuessById(int id);
    }
}
