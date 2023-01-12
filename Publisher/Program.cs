using System;
using System.Linq;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            // var factory = new ConnectionFactory { HostName = "localhost" };
            // using var connection = factory.CreateConnection();
            // using var channel = connection.CreateModel();
            // channel.QueueDeclare(queue: "myQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            //
            // var messageList = args.Length > 0 ? args : new[] { "default message" };
            // foreach (var message in messageList)
            // {
            //     var processedMessage = TransformMessage(message);
            //     var encodedArg = Encoding.UTF8.GetBytes(processedMessage);
            //     channel.BasicPublish("", "myQueue", null, encodedArg);
            //     Console.WriteLine($"{DateTime.Now:HH:mm:ss} Published message : {processedMessage}");
            //     //channel.WaitForConfirmsOrDie(TimeSpan.FromSeconds(5));
            //     if (!message.Equals(messageList.Last()))
            //     {
            //         Thread.Sleep(2000);
            //     }
            // }

            var p = new Publisher();
            p.SendMessages(args);
        }

    }
}