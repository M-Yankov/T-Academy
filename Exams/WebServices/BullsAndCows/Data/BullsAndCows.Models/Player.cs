namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class Player : IdentityUser
    {
        private ICollection<Guess> guesses;
        private ICollection<Notification> notification;

        public Player()
        {
            this.guesses = new HashSet<Guess>();
            this.notification = new HashSet<Notification>();
        }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Rank { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Player> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
