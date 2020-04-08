using System;
using System.Text;
using System.Threading;
using Common.Core;
using Common.Models;
using Newtonsoft.Json;

namespace SenderApp.Core
{
    public class RabbitMQService : IDisposable
    {
        private IDataStorage _dataStorage;

        public RabbitMQService(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public void Run()
        {
            try
            {
                _dataStorage.Start();

                var index = 0;

                while(true)
                {
                    _dataStorage.DoWork(model =>
                    {
                        var json = JsonConvert.SerializeObject(new MessageModel($"Message #{++index}"));
                        var bytes = Encoding.UTF8.GetBytes(json);

                        model.BasicPublish(exchange: "", routingKey: _dataStorage.DefaultQueue, mandatory: false, basicProperties: null, body: bytes);

                        Console.WriteLine($"Data: {json} was send on {_dataStorage.DefaultQueue} queue");
                        Console.WriteLine("Waiting 10 seconds until send next message...");
                        Thread.Sleep(TimeSpan.FromSeconds(1));

                    });                  
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"Non known exception was occour {err.Message}");
            }
        }

        public void Dispose()
        {
            _dataStorage?.Dispose();
        }
    }
}
