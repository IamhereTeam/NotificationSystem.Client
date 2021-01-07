using Prism.Regions;
using NS.Client.Core;
using Prism.Commands;
using NS.Client.Core.Mvvm;
using System.Windows.Controls;
using NS.Client.Services.Interfaces;

namespace NS.Client.Modules.ModuleName.ViewModels
{
    public class ViewNewNotificationViewModel : RegionViewModelBase
    {
        public DelegateCommand<PasswordBox> LoginCommand { get; private set; }

        private readonly IAccountService _accountService;

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _validationMessage;
        public string ValidationMessage
        {
            get { return _validationMessage; }
            set { SetProperty(ref _validationMessage, value); }
        }

        public ViewNewNotificationViewModel(IRegionManager regionManager, IAccountService accountService) :
            base(regionManager)
        {
            _accountService = accountService;
            LoginCommand = new DelegateCommand<PasswordBox>(Login);
        }

        private async void Login(PasswordBox password)
        {
            IsBusy = true;
            try
            {
                ValidationMessage = string.Empty;

                var data = await _accountService.Login(Username, password.Password);

                if (data.Succeeded)
                {
                    RegionManager.RequestNavigate(RegionNames.MainRegion, "ViewDashboard");
                    return;
                }

                if (data.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    ValidationMessage = "Username or password is incorrect";
                    return;
                }
            }
            catch { }
            finally
            {
                IsBusy = false;
            }

            ValidationMessage = "Something went wrong, please contact support";
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // Here we can get the JWT from local storage and automatically login
        }
    }
}
