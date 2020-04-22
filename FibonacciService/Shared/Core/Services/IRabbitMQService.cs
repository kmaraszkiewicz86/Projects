using System;
using Core.Models;
using RabbitMQ.Client.Events;

namespace Core.Services
{
    public interface IRabbitMqService
    {
        event EventHandler<BasicDeliverEventArgs> Received;

        void Start();

        void Send(FibRequest model);

        void StartRevivingRequests();

        void BasicConsume();
    }
}
