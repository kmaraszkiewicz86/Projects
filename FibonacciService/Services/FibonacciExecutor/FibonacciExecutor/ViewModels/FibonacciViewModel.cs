using System;
using System.Collections.Generic;
using System.Text;
using Core.Services;

namespace FibonacciExecutor.ViewModels
{
    public class FibonacciViewModel: BaseViewModel
    {
        private string _numberToCalculate;

        public string NumberToCalculate
        {
            get => _numberToCalculate;
            set
            {
                _numberToCalculate = value;
                OnPropertyChanged("NumberToCalculate");
            }
        }

        private string _result;

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }
    }
}
