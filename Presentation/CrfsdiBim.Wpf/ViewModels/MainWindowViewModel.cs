using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrfsdiBim.Core.Configuration;
using CrfsdiBim.Core.Domain;
using CrfsdiBim.Core.Domain.Projects;
using CrfsdiBim.Data;
using CrfsdiBim.Services.Projects;
using Serilog;
using System;
using System.Windows.Forms;

namespace CrfsdiBim.Wpf.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title = "CommunityToolkit.Mvvm Application";

        private ILogger _logger;
        private readonly IDbContextFactory _contextFactory;
        private IRouteService _routeService;
        private ITunnelService _tunnelService;

        public MainWindowViewModel(ILogger logger, IDbContextFactory contextFactory,
            IRouteService routeService, ITunnelService tunnelService)
        {
            _logger = logger;
            _routeService = routeService;
            _tunnelService = tunnelService;
            _contextFactory = contextFactory;
        }

        [RelayCommand]
        public void DatabaseInit()
        {
            try
            {
                //DbConnection dbConnection = new SQLiteConnection(CrfsdiBimConfig.ConnectionString);
                var ctx = _contextFactory.CreateDbContext(CrfsdiBimConfig.ConnectionString);

                Route route = new Route
                {
                    Name = "route1",
                };
                ctx.Routes.Add(route);

                Tunnel tunnel = new Tunnel
                {
                    Name = "tunnel1",
                    RouteId = route.Id
                };
                ctx.Tunnels.Add(tunnel);

                ctx.SaveChanges();
                MessageBox.Show("数据库初始化成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库初始化失败！" + Environment.NewLine + ex.Message);
                _logger.Error(ex, ex.Message);
            }
        }

        [RelayCommand]
        public void Create()
        {
            try
            {
                RouteModel routeModel = new RouteModel
                {
                    Name = "route2",
                };

                var route = Mapper.Map<Route>(routeModel);
                _routeService.Insert(route);

                TunnelModel tunnelModel = new TunnelModel
                {
                    Name = "tunnel2",
                };

                var tunnel = Mapper.Map<Tunnel>(tunnelModel);

                route = _routeService.GetById(route.Id);
                tunnel.Route = route;
                tunnel.RouteId = route.Id;
                _tunnelService.Insert(tunnel);

                MessageBox.Show("创建成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建失败！" + Environment.NewLine + ex.Message);
                _logger.Error(ex, ex.Message);
            }
        }
    }
}