namespace BullsAndCows.Data
{
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public interface IBullsAndCowsSystem
    {
        IRepository<Game> Games { get; }

        IRepository<Player> Players { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<Notification> Notifications { get; }

        int SaveChanges();
    }
}
