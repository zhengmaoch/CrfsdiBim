using Autofac;
using CrfsdiBim.Core.Data;
using CrfsdiBim.Core.Infrastructure.DependencyManagement;
using CrfsdiBim.Core.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Builder;
using Autofac.Core;
using System.Reflection;
using System.Runtime;
using CrfsdiBim.Core.Configuration;
using CrfsdiBim.Data;
using CrfsdiBim.Services;

namespace CrfsdiBim.Wpf.Framework.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, CrfsdiBimConfig config)
        {
            //data layer
            //var dataSettingsManager = new DataSettingsManager();
            //var dataProviderSettings = dataSettingsManager.LoadSettings();
            //builder.Register(c => dataSettingsManager.LoadSettings()).As<DataSettings>();
            //builder.Register(x => new EfDataProviderManager(x.Resolve<DataSettings>())).As<BaseDataProviderManager>().InstancePerDependency();

            //builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();

            //if (dataProviderSettings != null && dataProviderSettings.IsValid())
            //{
            //    var efDataProviderManager = new EfDataProviderManager(dataSettingsManager.LoadSettings());
            //    var dataProvider = efDataProviderManager.LoadDataProvider();
            //    dataProvider.InitConnectionFactory();

            //    builder.Register<IDbContext>(c => new CrfsdiBimObjectContext(dataProviderSettings.DataConnectionString)).InstancePerLifetimeScope();
            //}
            //else
            builder.Register<IDbContext>(c => new CrfsdiBimObjectContext()).InstancePerLifetimeScope();

            //repositories
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //services
            builder.RegisterType<RouteService>().As<IRouteService>().InstancePerLifetimeScope();
            builder.RegisterType<TunnelService>().As<ITunnelService>().InstancePerLifetimeScope();

            //register all settings
            builder.RegisterSource(new SettingsSource());

            //event consumers
            //var consumers = typeFinder.FindClassesOfType(typeof(IConsumer<>)).ToList();
            //foreach (var consumer in consumers)
            //{
            //    builder.RegisterType(consumer)
            //        .As(consumer.FindInterfaces((type, criteria) =>
            //        {
            //            var isMatch = type.IsGenericType && ((Type)criteria).IsAssignableFrom(type.GetGenericTypeDefinition());
            //            return isMatch;
            //        }, typeof(IConsumer<>)))
            //        .InstancePerLifetimeScope();
            //}
        }

        /// <summary>
        /// Gets order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }


    /// <summary>
    /// Setting source
    /// </summary>
    public class SettingsSource : IRegistrationSource
    {
        static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
            "BuildRegistration",
            BindingFlags.Static | BindingFlags.NonPublic);

        /// <summary>
        /// Registrations for
        /// </summary>
        /// <param name="service">Service</param>
        /// <param name="registrations">Registrations</param>
        /// <returns>Registrations</returns>
        public IEnumerable<IComponentRegistration> RegistrationsFor(
            Service service,
            Func<Service, IEnumerable<IComponentRegistration>> registrations)
        {
            var ts = service as TypedService;
            if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
            {
                var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
                yield return (IComponentRegistration)buildMethod.Invoke(null, null);
            }
        }

        //static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
        //{
        //    return RegistrationBuilder
        //        .ForDelegate((c, p) =>
        //        {
        //            var currentStoreId = c.Resolve<IStoreContext>().CurrentStore.Id;
        //            //uncomment the code below if you want load settings per store only when you have two stores installed.
        //            //var currentStoreId = c.Resolve<IStoreService>().GetAllStores().Count > 1
        //            //    c.Resolve<IStoreContext>().CurrentStore.Id : 0;

        //            //although it's better to connect to your database and execute the following SQL:
        //            //DELETE FROM [Setting] WHERE [StoreId] > 0
        //            return c.Resolve<ISettingService>().LoadSetting<TSettings>(currentStoreId);
        //        })
        //        .InstancePerLifetimeScope()
        //        .CreateRegistration();
        //}

        /// <summary>
        /// Is adapter for individual components
        /// </summary>
        public bool IsAdapterForIndividualComponents { get { return false; } }
    }
}
