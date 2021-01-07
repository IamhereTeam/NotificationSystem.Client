using NS.DTO.Acount;
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
        private readonly IDepartmentService _departmentService;

        private ObservableCollection<UserNotificationModel> _notifications;
        public ObservableCollection<UserNotificationModel> Notifications
        {
            get { return _notifications; }
            set { SetProperty(ref _notifications, value); }
        }

        private ObservableCollection<DepartmentModel> _allDepartments;
        public ObservableCollection<DepartmentModel> AllDepartments
        {
            get { return _allDepartments; }
            set { SetProperty(ref _allDepartments, value); }
        }

        private DepartmentModel _selectedDepartments;
        public DepartmentModel SelectedDepartments
        {
            get { return _selectedDepartments; }
            set { SetProperty(ref _selectedDepartments, value); }
        }

        public ViewNotificationViewModel(IRegionManager regionManager, INotificationService notificationService, IDepartmentService departmentService) :
            base(regionManager)
        {
            _notificationService = notificationService;
            _departmentService = departmentService;
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var notificationResult = await _notificationService.GetAll();
            var departmentResult = await _departmentService.GetAll();

            if (departmentResult.Succeeded)
            {
                AllDepartments = departmentResult.Data.ToObservable();
            }

            if (notificationResult.Succeeded)
            {
                Notifications = notificationResult.Data.ToObservable();
            }
        }
    }
}
