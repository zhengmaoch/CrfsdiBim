using AutoMapper;
using CrfsdiBim.Core.Domain;
using CrfsdiBim.Services;
using CrfsdiBim.Wpf.Infrastructure.Mapper;
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

            RouteModel route = new RouteModel();
            route.Name = "route1";
            route.Active = true;
            route.Deleted = false;
            route.CreatedTime = DateTime.Now;
            route.UpdatedTime = DateTime.Now;
            //RouteService.Add(route);

            TunnelModel tunnel = new TunnelModel();
            tunnel.Name = "tunnel1";
            tunnel.Active = true;
            tunnel.Deleted = false;
            tunnel.CreatedTime = DateTime.Now;
            tunnel.UpdatedTime = DateTime.Now;
            //tunnel.RouteId = route.Id;
            tunnel.Route = route;
            //TunnelService.Add(tunnel);

            _routeService.InsertRoute(Mapper.Map<Route>(route));
            _tunnelService.InsertTunnel(Mapper.Map<Tunnel>(tunnel));
        }


    }
}
