using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace ServiceBusExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connString = "service bus connection string";
            var queueClient = new QueueClient(connString, "queue name");

            Console.WriteLine("Press any key or q for exit:");

            var lastKey = ' ';
            lastKey = Console.ReadKey().KeyChar;
            var count = 1;

            while (lastKey != 'q')
            {
                var body = $"Message to stocktransfers #{count++}";
                var message = new Message(Encoding.UTF8.GetBytes(body));
                await queueClient.SendAsync(message);
                Console.WriteLine("");
                Console.WriteLine($"Sent {body}");
                lastKey = Console.ReadKey().KeyChar;
            }
        }
    }
}