using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrfsdiBim.Core.Domain;
using CrfsdiBim.Core.Domain.Projects;
using CrfsdiBim.Services.Projects;
using Serilog;
using System;

namespace CrfsdiBim.Wpf.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title = "CommunityToolkit.Mvvm Application";

        private ILogger _logger;
        private IRouteService _routeService;
        private ITunnelService _tunnelService;

        public MainWindowViewModel(ILogger logger, IRouteService routeService, ITunnelService tunnelService)
        {
            _logger = logger;
            _routeService = routeService;
            _tunnelService = tunnelService;
        }

        [RelayCommand]
        public void Create()
        {
            try
            {
                RouteModel routeModel = new RouteModel
                {
                    Name = "route1",
                    Active = true,
                    Deleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                };

                var route = Mapper.Map<Route>(routeModel);
                _routeService.Insert(route);

                TunnelModel tunnelModel = new TunnelModel
                {
                    Name = "tunnel1",
                    Active = true,
                    Deleted = false,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                };

                var tunnel = Mapper.Map<Tunnel>(tunnelModel);

                route = _routeService.GetById(route.Id);
                tunnel.Route = route;
                tunnel.RouteId = route.Id;
                _tunnelService.Insert(tunnel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
            }
        }
    }
}