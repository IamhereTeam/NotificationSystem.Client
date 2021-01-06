using Prism.Regions;
using NS.Client.Core.Mvvm;
using NS.Client.Services.Interfaces;

namespace NS.Client.Modules.ModuleName.ViewModels
{
    public class ViewAccountViewModel : RegionViewModelBase
    {
        private readonly IAccountService _accountService;

        public ViewAccountViewModel(IRegionManager regionManager, IAccountService accountService) :
            base(regionManager)
        {
            _accountService = accountService;
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var result = await _accountService.GetAcountSettings();

            if (result.Succeeded)
            {
                
            }
        }
    }
}
