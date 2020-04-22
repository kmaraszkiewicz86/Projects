using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Core.Models;
using Core.Services;
using RabbitMQ.Client.Events;

namespace FibonacciExecutor.ViewModels
{
    public class FibonacciCollectionViewModel : BaseViewModel
    {
        private IRabbitMqService _rabbitMqService;
        private IFibCalcService _fibCalcService;
        private IFibDbService _fibDbService;

        private object _locker = new object();

        private ObservableCollection<FibonacciViewModel> _fibonacciViewModels;

        public ObservableCollection<FibonacciViewModel> FibonacciViewModels
        {
            get => _fibonacciViewModels;
            set
            {
                if (_fibonacciViewModels == null)
                {
                    _fibonacciViewModels = new ObservableCollection<FibonacciViewModel>();
                }

                _fibonacciViewModels = value;
                OnPropertyChanged("FibonacciViewModels");
            }
        }

        public FibonacciCollectionViewModel(IRabbitMqService rabbitMqService, 
            IFibCalcService fibCalcService,
            IFibDbService fibDbService)
        {
            _fibonacciViewModels = new ObservableCollection<FibonacciViewModel>();
            _rabbitMqService = rabbitMqService;
            _fibCalcService = fibCalcService;
            _fibDbService = fibDbService;
            _rabbitMqService.Received += _rabbitMqService_Received;
        }

        public void StartGetRequests()
        {
            _rabbitMqService.Start();
            _rabbitMqService.StartRevivingRequests();
            _rabbitMqService.BasicConsume();
        }

        private void _rabbitMqService_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var json = Encoding.UTF8.GetString(body);
            FibRequest model;

            try
            {
                model = JsonSerializer.Deserialize<FibRequest>(json);
            }
            catch (JsonException)
            {
                return;
            }

            new Task(arg =>
            {
                var numberToCalculate = (long)arg;
                var start = DateTime.UtcNow;
                var result = _fibCalcService.Calculate(numberToCalculate);

                _fibDbService.CalculateAsync(new FibResult
                {
                    ElementNumber = numberToCalculate,
                    Result = result
                }).Wait();

                lock (_locker)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        FibonacciViewModels.Insert(0,new FibonacciViewModel
                        {
                            NumberToCalculate = numberToCalculate.ToString(),
                            Result = result.ToString(),
                            Time = (DateTime.UtcNow - start).ToString()
                        });
                    });
                }

            }, model.NumberToCalculate).Start();
        }
    }
}
