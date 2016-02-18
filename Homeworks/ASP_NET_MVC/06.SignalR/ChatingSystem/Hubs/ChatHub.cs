using Microsoft.AspNet.SignalR;

namespace ChatingSystem.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            this.Clients.All.addMessage(message, this.Context.User.Identity.Name);
        }
    }
}