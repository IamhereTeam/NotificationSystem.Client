using Prism.Ioc;
using Prism.Regions;
using NS.Client.Core;
using Prism.Modularity;
using NS.Client.Modules.ModuleName.Views;

namespace NS.Client.Modules.ModuleName
{
    public class ModuleNameModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleNameModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewLogin");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewLogin>();
            containerRegistry.RegisterForNavigation<ViewDashboard>();
        }
    }
}