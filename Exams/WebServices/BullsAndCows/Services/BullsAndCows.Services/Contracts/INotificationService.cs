namespace BullsAndCows.Services.Contracts
{
    using System.Linq;
    using BullsAndCows.Models;

    public interface INotificationService
    {
        void SendNotificationToUser(string userId, string message, MessageState state, MessageType type, int gameId);

        IQueryable<Notification> GetNotificationsForUser(string userId, int page);

        Notification GetNextNotificationForUser(string userId);
    }
}
