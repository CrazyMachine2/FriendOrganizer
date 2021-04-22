using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.Data.Repositories;
using FriendOrganizer.UI.View.Services;
using FriendOrganizer.UI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prism.Events;
using System;
using System.Windows;

namespace FriendOrganizer.UI
{
    public partial class App : Application
    {

        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => ConfigureServices(context.Configuration, services))
                .Build();
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            // View Models
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddScoped<INavigationViewModel, NavigationViewModel>();
            services.AddTransient<IFriendDetailViewModel, FriendDetailViewModel>();

            //Repos
            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddScoped<IFriendLookupDataService, LookupDataService>();
            services.AddScoped<IProgrammingLanguageLookupDataService, LookupDataService>();
            
            //Db contexts
            services.AddDbContext<FriendOrganizerContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("FriendOrganizerDb")),
                ServiceLifetime.Transient, ServiceLifetime.Transient);

            //Other
            services.AddSingleton<IEventAggregator, EventAggregator>();
            services.AddTransient<Func<IFriendDetailViewModel>>(cont => () => cont.GetRequiredService<IFriendDetailViewModel>());
            services.AddScoped<IMessageDialogService, MessageDialogService>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unhandled exception: " + e.Exception.Message);
            e.Handled = true;
        }
    }
}
