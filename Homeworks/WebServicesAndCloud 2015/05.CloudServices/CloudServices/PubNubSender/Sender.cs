namespace PubNubSender
{
    using System;
    using CloudServices.Common;
    using PubNubMessaging.Core;

    public class Sender
    {
        private static Pubnub client;

        public static void Main()
        {
            Console.Title = "Sender";
            client = new Pubnub(GlobalConstatns.PubNubPublishKey, GlobalConstatns.PubNubSecretKey);

            Console.WriteLine("Send message to pubnub:");

            while (true)
            {
                string message = Console.ReadLine();
                SendMessage(message);
            }
        }

        private static void SendMessage(string text)
        {
            client.Publish<string>(
                "PubNubDemo",
                text, 
                (msg) => Console.WriteLine(msg),
                (err) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(err.Message);
                Console.ResetColor();
            });
        }
    }
}
