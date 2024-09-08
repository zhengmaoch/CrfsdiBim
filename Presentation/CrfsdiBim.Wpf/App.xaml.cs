using CrfsdiBim.Core.Data;
using CrfsdiBim.Data;
using CrfsdiBim.Services.Projects;
using CrfsdiBim.Wpf.ViewModels;
using CrfsdiBim.Wpf.Views;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Windows;

namespace CrfsdiBim.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        public App()
        {
            Services = ConfigureServices();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ILogger>(_ =>
            {
                return new LoggerConfiguration().MinimumLevel
                .Debug()
                    .WriteTo.File("log.txt")
                    .CreateLogger();
            });
            services.AddSingleton<IDbContextFactory, DbContextFactory>();
            services.AddSingleton(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddSingleton<IRouteService, RouteService>();
            services.AddSingleton<ITunnelService, TunnelService>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MainWindow>(sp => new MainWindow { DataContext = sp.GetService<MainWindowViewModel>() });

            return services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = Services.GetService<MainWindow>();
            mainWindow!.Show();
        }
    }
}