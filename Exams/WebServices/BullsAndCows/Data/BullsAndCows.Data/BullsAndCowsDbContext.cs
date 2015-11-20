namespace BullsAndCows.Data
{
    using System;
    using System.Data.Entity;
    using BullsAndCows.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BullsAndCowsDbContext : IdentityDbContext<Player>
    {
        public BullsAndCowsDbContext() : base("BullsAndCows", throwIfV1Schema: false)
        {
        }
        
        public virtual IDbSet<Notification> Notifications { get; set; }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Guess> Guesses { get; set; }
         
        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }
    }
}