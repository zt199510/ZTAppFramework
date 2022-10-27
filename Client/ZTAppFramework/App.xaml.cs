using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using System.Windows;
using ZTAppFramework.Admin;
using ZTAppFramework.PictureMarker;

namespace ZTAppFramework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override Window CreateShell() => null;

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AdminModule>();
         
            base.ConfigureModuleCatalog(moduleCatalog);
        }


        protected override IContainerExtension CreateContainerExtension()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAutoMapper(config =>
            {
                config.AddProfile<AdminMapper>();
            });
            return new DryIocContainerExtension(new Container(CreateContainerRules()).WithDependencyInjectionAdapter(serviceCollection));

        }

        protected override async void OnInitialized()
        {
            var appStart = ContainerLocator.Container.Resolve<AppStartService>();
            MainWindow = await appStart.CreateShell(this);
            base.OnInitialized();
        }
    }
}
