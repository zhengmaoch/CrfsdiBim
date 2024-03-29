﻿using AutoMapper;
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

            RouteModel routeModel = new RouteModel
            {
                Name = "route1",
                Active = true,
                Deleted = false,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };

            var route = Mapper.Map<Route>(routeModel);
            _routeService.InsertRoute(route);

            TunnelModel tunnelModel = new TunnelModel
            {
                Name = "tunnel1",
                Active = true,
                Deleted = false,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };

            var tunnel = Mapper.Map<Tunnel>(tunnelModel);

            route = _routeService.GetRouteById(route.Id);
            tunnel.Route = route;
            tunnel.RouteId = route.Id;
            _tunnelService.InsertTunnel(tunnel);
        }


    }
}
