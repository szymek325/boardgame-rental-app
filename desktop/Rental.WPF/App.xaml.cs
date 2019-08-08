using System;
using System.IO;
using System.Windows;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rental.Core;
using Rental.Core.Configuration;
using Rental.Core.Notifications;
using Rental.DataAccess;
using Rental.WPF.View.Base;
using Rental.WPF.View.Clients;
using Rental.WPF.View.Games;
using Rental.WPF.View.Rentals;
using Rental.WPF.ViewModel.Clients;

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
            services.AddAutoMapper(typeof(App),typeof(CoreModule),typeof(EntityFrameworkModule));
            //services.AddMediatR(typeof(App), typeof(CoreModule));
            services.AddMediatR(typeof(CoreModule));

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

            services.AddSingleton<INotificationHandler<NewClientAddedNotification>, ClientsViewModel>();
//            services.AddTransient<AddClientWindow>();
        }
    }
}