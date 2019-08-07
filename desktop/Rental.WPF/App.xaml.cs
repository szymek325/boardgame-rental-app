using System;
using System.IO;
using System.Windows;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rental.Core;
using Rental.Core.Configuration;
using Rental.DataAccess;
using Rental.WPF.View;
using Rental.WPF.View.Base;
using Rental.WPF.View.Clients;
using Rental.WPF.ViewModel;

namespace Rental.WPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", true, true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(App));
            var connectionStrings = new ConnectionStrings();
            Configuration.GetSection(nameof(ConnectionStrings)).Bind(connectionStrings);
            services.AddCoreModule();
            services.AddDataAccessModule(connectionStrings);

            services.AddTransient(typeof(MainWindow));
            services.AddTransient<ClientsPage>();
            services.AddTransient<GamesPage>();
            services.AddTransient<RentalsPage>();
            services.AddTransient<MenuPage>();
//
            services.AddTransient<ClientListViewModel>();
//            services.AddTransient<AddClientWindow>();
        }
    }
}