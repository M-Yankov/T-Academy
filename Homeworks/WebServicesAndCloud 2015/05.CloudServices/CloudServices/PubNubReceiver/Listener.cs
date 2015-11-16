namespace PubNubReceiver
{
    using System;
    using CloudServices.Common;
    using PubNubMessaging.Core;

    public class Listener
    {
        private static Pubnub client;

        public static void Main()
        {
            Console.Title = "Listener";
            client = new Pubnub(GlobalConstatns.PubNubPublishKey, GlobalConstatns.PubNubSecretKey);

            client.Subscribe<string>(
                "PubNubDemo",
                (msg) => Console.WriteLine(msg),
                (msg) => Console.WriteLine(msg),
                (err) => Console.WriteLine(err.Message));

            Console.WriteLine("Wait for messages or just hit enter to exit;");
            Console.ReadLine();
        }
    }
}
