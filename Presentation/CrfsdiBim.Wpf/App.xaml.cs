using AutoMapper;
using CrfsdiBim.Wpf.Infrastructure.Mapper;
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
