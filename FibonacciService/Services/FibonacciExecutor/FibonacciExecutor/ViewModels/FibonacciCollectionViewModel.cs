using System.Collections.ObjectModel;
using Core.Services;

namespace FibonacciExecutor.ViewModels
{
    public class FibonacciCollectionViewModel : BaseViewModel
    {
        private IRabbitMqService _rabbitMqService;

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

        public FibonacciCollectionViewModel(IRabbitMqService rabbitMqService)
        {
            _fibonacciViewModels = new ObservableCollection<FibonacciViewModel>();
            _rabbitMqService = rabbitMqService;
        }

        public void AddItems()
        {
            FibonacciViewModels.Add(new FibonacciViewModel
            {
                NumberToCalculate = "5",
                Result = "8"
            });
        }
    }
}
