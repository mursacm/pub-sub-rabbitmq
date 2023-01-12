using System;
using System.Linq;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace Publisher
{
    public class Publisher
    {
        private ConnectionFactory Factory { get; set; }
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }

        public Publisher()
        {
            Factory = new ConnectionFactory { HostName = "localhost" };
        }

        public void SendMessages(string[] messageList, bool waitForConfirmation = false)
        {
            SuccessCount = 0;
            FailedCount = 0;
            
            using var connection = Factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "myQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            foreach (var message in messageList)
            {
                var processedMessage = TransformMessage(message);
                var encodedArg = Encoding.UTF8.GetBytes(processedMessage);
                channel.BasicPublish("", "myQueue", null, encodedArg);
                Console.WriteLine($"{DateTime.Now:HH:mm:ss} Published message : {processedMessage}");
                if (waitForConfirmation)
                {
                    try
                    {
                        channel.WaitForConfirmsOrDie(TimeSpan.FromSeconds(5));
                        SuccessCount++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        FailedCount++;
                    }
                }
                if (!message.Equals(messageList.Last()))
                {
                    Thread.Sleep(2000);
                }
            }
        }
        
        // text transform
        public string TransformMessage(string message)
        {
            return message.ToUpper();
        }
    }
}