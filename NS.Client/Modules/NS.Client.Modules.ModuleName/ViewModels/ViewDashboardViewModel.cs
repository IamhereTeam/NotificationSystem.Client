using Prism.Regions;
using NS.Client.Core;
using NS.Client.Core.Mvvm;

namespace NS.Client.Modules.ModuleName.ViewModels
{
    public class ViewDashboardViewModel : RegionViewModelBase
    {
        public ViewDashboardViewModel(IRegionManager regionManager) :
            base(regionManager)
        {
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            RegionManager.RequestNavigate(RegionNames.NavigationRegion, "ViewNavigation");
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewNotification");
        }
    }
}
