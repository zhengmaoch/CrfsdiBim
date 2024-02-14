using CrfsdiBim.Core.Domain;
using CrfsdiBim.Services;
using Prism.Mvvm;
using System;

namespace CrfsdiBim.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        IRouteService _routeService;
        ITunnelService _tunnelService;

        public MainWindowViewModel(IRouteService routeService, ITunnelService tunnelService)
        {
            _routeService = routeService;
            _tunnelService = tunnelService;

            Route route = new Route();
            route.Name = "route1";
            route.Active = true;
            route.Deleted = false;
            route.CreatedTime = DateTime.Now;
            route.UpdatedTime = DateTime.Now;
            //RouteService.Add(route);

            Tunnel tunnel = new Tunnel();
            tunnel.Name = "tunnel1";
            tunnel.Active = true;
            tunnel.Deleted = false;
            tunnel.CreatedTime = DateTime.Now;
            tunnel.UpdatedTime = DateTime.Now;
            tunnel.RouteId = route.Id;
            tunnel.Route = route;
            //TunnelService.Add(tunnel);

            _routeService.InsertRoute(route);
            _tunnelService.InsertTunnel(tunnel);
        }


    }
}
