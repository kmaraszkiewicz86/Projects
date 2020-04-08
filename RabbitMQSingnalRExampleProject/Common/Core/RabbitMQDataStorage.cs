using System;
using RabbitMQ.Client;

namespace Common.Core
{
    public class RabbitMQHelper: IDataStorage
    {
        public string DefaultQueue => "MainQueue";

        private ConnectionFactory _factory;

        private IConnection _connection;

        private IModel _model;

        public void Start()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = _factory.CreateConnection();

            _model = _connection.CreateModel();

            _model.QueueDeclare(DefaultQueue,
                false,
                false,
                false,
                null);
        }

        public void DoWork(Action<IModel> action)
        {
            action(_model);
        }


        public void Dispose()
        {
            _model?.Dispose();
            _connection?.Dispose();  
        }
    }
}
