namespace BullsAndCows.Services
{
    using System.Linq;
    using BullsAndCows.Common;
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Contracts;

    public class ScoreService : IScoreService
    {
        private IBullsAndCowsSystem system;

        public ScoreService(IBullsAndCowsSystem bullsAndCowsSystem)
        {
            this.system = bullsAndCowsSystem;
        }

        public IQueryable<Player> GetTopPlayers()
        {
            return this.system
                .Players
                .All()
                .OrderByDescending(x => x.Rank)
                .ThenBy(x => x.UserName)
                .Take(GlobalConstants.EntitiesPerPage);
        }
    }
}