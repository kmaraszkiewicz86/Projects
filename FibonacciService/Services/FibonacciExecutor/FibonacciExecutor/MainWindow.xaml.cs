using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Core.Services;
using FibonacciExecutor.ViewModels;

namespace FibonacciExecutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FibonacciCollectionViewModel _fibonacciCollectionViewModel;

        public MainWindow(FibonacciCollectionViewModel fibonacciCollectionViewModel)
        {
            _fibonacciCollectionViewModel = fibonacciCollectionViewModel;

            InitializeComponent();
            DataContext = _fibonacciCollectionViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fibonacciCollectionViewModel.StartGetRequests();
        }

    }
}
