using CrfsdiBim.Core.Data;
using CrfsdiBim.Data;
using CrfsdiBim.Services;
using CrfsdiBim.Wpf.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrfsdiBim.Wpf
{
    class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // data layer
            containerRegistry.RegisterScoped<IDbContext>(c => new CrfsdiBimObjectContext());

            // repositories
            containerRegistry.RegisterScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // logger
            // services
            containerRegistry.RegisterScoped<IRouteService, RouteService>();
            containerRegistry.RegisterScoped<ITunnelService, TunnelService>();
        }
    }
}
