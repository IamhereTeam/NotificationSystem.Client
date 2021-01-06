using Prism.Ioc;
using System.Windows;
using NS.Client.Views;
using Prism.Modularity;
using NS.Client.Services;
using NS.Client.Services.Mock;
using NS.Client.Modules.ModuleName;
using NS.Client.Services.Interfaces;

namespace NS.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var endPoint = "https://localhost:5001/";
            NSApiClient httpClient = new NSApiClient(endPoint);

            containerRegistry.RegisterInstance<NSApiClient>(httpClient);
            containerRegistry.RegisterSingleton<IAccountService, AccountService>();
            containerRegistry.RegisterSingleton<IDepartmentService, DepartmentService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
