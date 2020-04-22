using System;
using System.Configuration;
using System.Windows;
using Core.AppSettings;
using Core.Core;
using Core.Helpers;
using Core.Services;
using FibonacciExecutor.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FibonacciExecutor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider _serviceProvider { get; private set; }

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = ConnectionBuilderHelper.BuildDefault();

            services.Configure<RabbitMq>
                (configuration.GetSection(nameof(RabbitMq)));

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionString"]));

            services.AddScoped<IRabbitMqService, RabbitMqService>();
            services.AddScoped<IFibCalcService, FibCalcService>();
            services.AddScoped<IFibDbService, FibDbService>();
            services.AddSingleton<FibonacciCollectionViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
