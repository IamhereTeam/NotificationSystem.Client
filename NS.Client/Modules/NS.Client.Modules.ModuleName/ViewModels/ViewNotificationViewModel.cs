using System.Linq;
using NS.DTO.Acount;
using Prism.Regions;
using NS.Client.Common;
using NS.Client.Core.Mvvm;
using NS.DTO.Notification;
using System.Collections.Generic;
using NS.Client.Services.Interfaces;
using System.Collections.ObjectModel;

namespace NS.Client.Modules.ModuleName.ViewModels
{
    public class ViewNotificationViewModel : RegionViewModelBase
    {
        private readonly INotificationService _notificationService;
        private readonly IDepartmentService _departmentService;

        private ObservableCollection<UserNotificationModel> _notifications;
        public ObservableCollection<UserNotificationModel> Notifications
        {
            get { return _notifications?.Where(Filter)?.ToObservable(); }
            set { SetProperty(ref _notifications, value); }
        }

        private ObservableCollection<DepartmentModel> _filterDepartments;
        public ObservableCollection<DepartmentModel> FilterDepartments
        {
            get { return _filterDepartments; }
            set { SetProperty(ref _filterDepartments, value); }
        }

        private DepartmentModel _selectedDepartment;
        public DepartmentModel SelectedDepartment
        {
            get { return _selectedDepartment; }
            set
            {
                SetProperty(ref _selectedDepartment, value);
                RaisePropertyChanged(nameof(Notifications));
            }
        }

        public ViewNotificationViewModel(IRegionManager regionManager, INotificationService notificationService, IDepartmentService departmentService) :
            base(regionManager)
        {
            _notificationService = notificationService;
            _departmentService = departmentService;
        }

        private bool Filter(UserNotificationModel userNotification)
        {
            return SelectedDepartment == null || SelectedDepartment.Id == 0 || userNotification.Sender.DepartmentId == SelectedDepartment.Id;
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var notificationResult = await _notificationService.GetAll();
            var departmentResult = await _departmentService.GetAll();

            if (!departmentResult.Succeeded || !notificationResult.Succeeded) return;

            var filterDepartments = new List<DepartmentModel> { new DepartmentModel { Id = 0, Name = "All" } };
            filterDepartments.AddRange(departmentResult.Data);
            FilterDepartments = filterDepartments.ToObservable();
            SelectedDepartment = filterDepartments.First();

            Notifications = notificationResult.Data.ToObservable();
        }
    }
}