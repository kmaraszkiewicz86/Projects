using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Core;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;
using WebApi.HubConfig;

namespace WebApi.BackgroundServices
{
    public class RabbitMQService: BackgroundService
    {
        private IDataStorage _dataStorage;

        private IHubContext<MessageHub> _hub;

        public RabbitMQService(IHubContext<MessageHub> hub)
        {
            _hub = hub;
            _dataStorage = new RabbitMQHelper();
            _dataStorage.Start();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _dataStorage.DoWork(model =>
            {
                var eventingBasicConsumer = new EventingBasicConsumer(model);

                eventingBasicConsumer.Received += (object sender, BasicDeliverEventArgs e) =>
                {
                    var message = Encoding.UTF8.GetString(e.Body);

                    _hub.Clients.All.SendAsync("messages", message).GetAwaiter();

                    model.BasicAck(e.DeliveryTag, false);
                };
            });
        }

        private void EventingBasicConsumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body);

            _hub.Clients.All.SendAsync("messages", message).GetAwaiter();
        }

        public override void Dispose()
        {
            _dataStorage?.Dispose();
        }
    }
}
