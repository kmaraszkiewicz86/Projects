using System;
using Common.Core;
using SenderApp.Core;

namespace SenderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var service = new RabbitMQService(new RabbitMQHelper()))
            {
                service.Run();
            }
        }
    }
}
