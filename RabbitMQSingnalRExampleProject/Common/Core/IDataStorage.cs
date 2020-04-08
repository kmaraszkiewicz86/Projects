using System;
using RabbitMQ.Client;

namespace Common.Core
{
    public interface IDataStorage : IDisposable
    {
        public string DefaultQueue { get; }

        public void Start();

        public void DoWork(Action<IModel> action);
    }
}
