using Prism.Regions;
using Prism.Commands;
using NS.Client.Core;
using NS.Client.Core.Mvvm;
using NS.Client.Services.Interfaces;
using System;

namespace NS.Client.Modules.ModuleName.ViewModels
{
    public class ViewNavigationViewModel : RegionViewModelBase
    {
        private readonly IAccountService _accountService;
        public DelegateCommand LogoutCommand { get; private set; }
        public DelegateCommand AccountCommand { get; private set; }
        public DelegateCommand ViewNotificationsCommand { get; private set; }
        public DelegateCommand NewNotificationCommand { get; private set; }

        private string _userFullName;
        public string UserFullName
        {
            get { return _userFullName; }
            set { SetProperty(ref _userFullName, value); }
        }

        public ViewNavigationViewModel(IRegionManager regionManager, IAccountService accountService) :
            base(regionManager)
        {
            _accountService = accountService;
            LogoutCommand = new DelegateCommand(Logout);
            AccountCommand = new DelegateCommand(Account);
            ViewNotificationsCommand = new DelegateCommand(ViewNotifications);
            NewNotificationCommand = new DelegateCommand(NewNotification);
        }

        private void NewNotification()
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewNewNotification");
        }

        private void ViewNotifications()
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewNotification");
        }

        private void Account()
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewAccount");
        }

        private async void Logout()
        {
            _ = await _accountService.Logout();
            RegionManager.RequestNavigate(RegionNames.MainRegion, "ViewLogin");
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var result = await _accountService.GetAcount();

            if (result.Succeeded)
            {
                var _user = result.Data;
                UserFullName = $"{_user.FirstName} {_user.LastName} / {_user.Department.Name}";
            }
        }
    }
}
