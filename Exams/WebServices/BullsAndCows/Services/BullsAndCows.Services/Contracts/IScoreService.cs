namespace BullsAndCows.Services.Contracts
{
    using System.Linq;
    using BullsAndCows.Models;

    public interface IScoreService
    {
        IQueryable<Player> GetTopPlayers();
    }
}