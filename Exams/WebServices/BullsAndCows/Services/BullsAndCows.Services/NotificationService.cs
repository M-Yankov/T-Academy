namespace BullsAndCows.Services
{
    using System;
    using System.Linq;
    using BullsAndCows.Common;
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.Services.Contracts;

    public class NotificationService : INotificationService
    {
        private IBullsAndCowsSystem system;

        public NotificationService(IBullsAndCowsSystem bullsAndCowsSystem)
        {
            this.system = bullsAndCowsSystem;
        }

        public void SendNotificationToUser(string userId, string message, MessageState state, MessageType type, int gameId)
        {
            Notification notification = new Notification()
            {
                GameId = gameId,
                Message = message,
                PlayerId = userId,
                State = state,
                Type = type,
                DateCreated = DateTime.Now
            };

            this.system.Notifications.Add(notification);
            this.system.SaveChanges();
        }

        public IQueryable<Notification> GetNotificationsForUser(string userId, int page)
        {
            return this.system
                .Notifications
                .All()
                .Where(x => x.PlayerId == userId)
                .OrderByDescending(x => x.State)
                .ThenBy(x => x.DateCreated)
                .Skip(page * GlobalConstants.NotificationsPerPage)
                .Take(GlobalConstants.NotificationsPerPage);
        }

        public Notification GetNextNotificationForUser(string userId)
        {
            return this.system
                .Notifications
                .All()
                .Where(x => x.PlayerId == userId && x.State == MessageState.Unread)
                .OrderBy(x => x.DateCreated)
                .FirstOrDefault();
        }
    }
}