using Prism.Regions;
using NS.Client.Common;
using NS.Client.Core.Mvvm;
using NS.DTO.Notification;
using System.Collections.ObjectModel;
using NS.Client.Services.Interfaces;

namespace NS.Client.Modules.ModuleName.ViewModels
{
    public class ViewNotificationViewModel : RegionViewModelBase
    {
        private readonly INotificationService _notificationService;

        private ObservableCollection<UserNotificationModel> _notifications;
        public ObservableCollection<UserNotificationModel> Notifications
        {
            get { return _notifications; }
            set { SetProperty(ref _notifications, value); }
        }

        public ViewNotificationViewModel(IRegionManager regionManager, INotificationService notificationService) :
            base(regionManager)
        {
            _notificationService = notificationService;
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var result = await _notificationService.GetAll();

            if (result.Succeeded)
            {
                Notifications = result.Data.ToObservable();
            }
        }
    }
}
