using System;
using System.Text;
using System.Threading;
using Common.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using WebApi.HubConfig;

namespace WebApi.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("api/Messages")]
    public class MessagesController : ControllerBase
    {
        private IDataStorage _dataStorage;

        private IHubContext<MessageHub> _hub;

        private const string QueueName = "DefaultQueue";

        public MessagesController(IHubContext<MessageHub> hub)
        {
            _hub = hub;
            _dataStorage = new RabbitMQHelper();
            _dataStorage.Start();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var timerManager = new TimerManager(() =>
            {
                _dataStorage.DoWork(model =>
                {
                    var eventingBasicConsumer = new EventingBasicConsumer(model);

                    eventingBasicConsumer.Received += (object sender, BasicDeliverEventArgs e) =>
                    {
                        var message = Encoding.UTF8.GetString(e.Body);

                        _hub.Clients.All.SendAsync("messages", message);
                    };


                    model.BasicConsume(queue: _dataStorage.DefaultQueue,
                        autoAck: true,
                        consumer: eventingBasicConsumer);

                });
            });

            return Ok(new { Message = "Request Completed" });
        }
    }

    public class TimerManager
    {
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;

        public DateTime TimerStarted { get; }

        public TimerManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 2000);
            TimerStarted = DateTime.Now;
        }

        public void Execute(object stateInfo)
        {
            _action();

            if ((DateTime.Now - TimerStarted).Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}
