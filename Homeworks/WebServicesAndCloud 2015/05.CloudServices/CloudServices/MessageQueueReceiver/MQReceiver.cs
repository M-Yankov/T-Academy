namespace MessageQueueReceiver
{
    using System;
    using IronMQ;
    using IronMQ.Data;
    using System.Threading;
    using CloudServices.Common;

    public class MQReceiver
    {
        public static void Main()
        {
            var client = new Client(GlobalConstatns.MQProjectID, GlobalConstatns.MQToken);
            Queue queue = client.Queue("TelerikDemo");
            Console.WriteLine("Listening for new messages from IronMQ server:");
            
            while (true)
            {
                Message msg = queue.Get();
                if (msg != null)
                {
                    Console.WriteLine(msg.Body);
                    queue.DeleteMessage(msg);
                }

                Thread.Sleep(100);
            }
        }
    }
}
