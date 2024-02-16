using AutoMapper;
using CrfsdiBim.Core.Configuration;
using CrfsdiBim.Core.Data;
using CrfsdiBim.Data;
using CrfsdiBim.Services;
using CrfsdiBim.Wpf.Infrastructure.Mapper;
using CrfsdiBim.Wpf.Views;
using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CrfsdiBim.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // AutoMapper Initialize
            Mapper.Initialize(m => { m.AddProfile<MapperProfile>(); });

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}
