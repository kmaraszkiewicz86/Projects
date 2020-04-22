using System;
using System.Text;
using System.Text.Json;
using Core.AppSettings;
using Core.Models;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Core.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        public event EventHandler<BasicDeliverEventArgs> Received;

        private readonly RabbitMq _rabbitMqSettings;
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        private EventingBasicConsumer _consumer;

        public RabbitMqService(RabbitMq rabbitMq)
        {
            _rabbitMqSettings = rabbitMq;
        }

        public RabbitMqService(IOptions<RabbitMq> rabbitMqSettingsOptions)
        {
            _rabbitMqSettings = rabbitMqSettingsOptions.Value;
        }

        public void Start()
        {
            _factory = new ConnectionFactory()
            {
                HostName = _rabbitMqSettings.Hostname
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: _rabbitMqSettings.QueueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public void Send(FibRequest model)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(model));

            _channel.BasicPublish(exchange: "",
                routingKey: _rabbitMqSettings.QueueName,
                basicProperties: null,
                body: body);
        }

        public void StartRevivingRequests()
        {
            _consumer = new EventingBasicConsumer(_channel);

            if (Received == null)
                throw new NullReferenceException(nameof(Received));

            _consumer.Received += Received;
        }

        public void BasicConsume()
        {
            _channel.BasicConsume(queue: _rabbitMqSettings.QueueName,
                autoAck: true,
                consumer: _consumer);
        }

        ~RabbitMqService()
        {
            if (Received != null)
            {
                _consumer.Received -= Received;
            }
            
            _channel?.Dispose();
            _connection?.Dispose();
            _consumer = null;
            _factory = null;
        }
    }
}
