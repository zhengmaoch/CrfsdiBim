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

            RouteModel routeModel = new RouteModel();
            routeModel.Name = "route1";
            routeModel.Active = true;
            routeModel.Deleted = false;
            routeModel.CreatedTime = DateTime.Now;
            routeModel.UpdatedTime = DateTime.Now;

            var route = Mapper.Map<Route>(routeModel);
            _routeService.InsertRoute(route);

            TunnelModel tunnelModel = new TunnelModel();
            tunnelModel.Name = "tunnel1";
            tunnelModel.Active = true;
            tunnelModel.Deleted = false;
            tunnelModel.CreatedTime = DateTime.Now;
            tunnelModel.UpdatedTime = DateTime.Now;

            var tunnel = Mapper.Map<Tunnel>(tunnelModel);

            route = _routeService.GetRouteById(route.Id);
            tunnel.Route = route;
            tunnel.RouteId = route.Id;
            _tunnelService.InsertTunnel(tunnel);
        }


    }
}
