using Prism.Regions;
using NS.Client.Core.Mvvm;

namespace NS.Client.Modules.ModuleName.ViewModels
{
    public class ViewNavigationViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewNavigationViewModel(IRegionManager regionManager) :
            base(regionManager)
        {
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
