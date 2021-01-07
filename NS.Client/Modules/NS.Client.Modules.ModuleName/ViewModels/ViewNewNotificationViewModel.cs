using Prism.Regions;
using Prism.Commands;
using NS.Client.Core.Mvvm;
using NS.DTO.Notification;
using System.Collections.Generic;
using NS.Client.Services.Interfaces;

namespace NS.Client.Modules.ModuleName.ViewModels
{
    public class ViewNewNotificationViewModel : RegionViewModelBase
    {
        public DelegateCommand SendCommand { get; private set; }

        private readonly IAccountService _accountService;
        private readonly IDepartmentService _departmentService;
        private readonly INotificationService _notificationService;
  
        private string _users;
        public string Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        private string _departments;
        public string Departments
        {
            get { return _departments; }
            set { SetProperty(ref _departments, value); }
        }

        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { SetProperty(ref _subject, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _validationMessage;
        public string ValidationMessage
        {
            get { return _validationMessage; }
            set { SetProperty(ref _validationMessage, value); }
        }

        public ViewNewNotificationViewModel(IRegionManager regionManager, IAccountService accountService, IDepartmentService departmentService, INotificationService notificationService) :
            base(regionManager)
        {
            _accountService = accountService;
            _departmentService = departmentService;
            _notificationService = notificationService;
            SendCommand = new DelegateCommand(Send);
        }

        private async void Send()
        {
            IsBusy = true;
            try
            {
                ValidationMessage = string.Empty;

                var newNotificationModel = new CreateNotificationModel()
                {
                    Departments = TryPars(Departments),
                    Users = TryPars(Users),
                    Notification = new NotificationModel { Subject = Subject, Message = Message }
                };

                var data = await _notificationService.Create(newNotificationModel);

                if (data.Succeeded)
                {
                    // show 'successfully saved' message
                    return;
                }
                else
                {
                    // show 'failed to save' message
                    ValidationMessage = "Failed to Send Notification!";
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

        private IEnumerable<int> TryPars(string multyValue)
        {
            if (string.IsNullOrWhiteSpace(multyValue)) yield break;

            foreach (var id in multyValue.Split(','))
            {
                yield return int.Parse(id);
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // Here we can get the JWT from local storage and automatically login
        }
    }
}
