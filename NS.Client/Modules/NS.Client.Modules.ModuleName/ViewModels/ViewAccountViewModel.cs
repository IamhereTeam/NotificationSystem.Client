using System.Linq;
using Prism.Regions;
using NS.DTO.Acount;
using NS.Client.Core;
using Prism.Commands;
using NS.Client.Common;
using NS.Client.Core.Mvvm;
using System.Collections.Generic;
using NS.Client.Services.Interfaces;
using System.Collections.ObjectModel;
using NS.Client.Modules.ModuleName.Models;

namespace NS.Client.Modules.ModuleName.ViewModels
{
    public class ViewAccountViewModel : RegionViewModelBase
    {
        private readonly IAccountService _accountService;
        private readonly IDepartmentService _departmentService;

        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand ResetPasswordCommand { get; private set; }

        private AccountVModel _account;
        public AccountVModel Account
        {
            get { return _account; }
            set { SetProperty(ref _account, value); }
        }

        private ObservableCollection<DepartmentVModel> _allDepartments;
        public ObservableCollection<DepartmentVModel> AllDepartments
        {
            get { return _allDepartments; }
            set { SetProperty(ref _allDepartments, value); }
        }

        public ViewAccountViewModel(IRegionManager regionManager, IAccountService accountService, IDepartmentService departmentService) :
            base(regionManager)
        {
            _accountService = accountService;
            _departmentService = departmentService;
            SaveCommand = new DelegateCommand(Save);
            ResetPasswordCommand = new DelegateCommand(ResetPassword);
        }

        private void ResetPassword()
        {
            RegionManager.RequestNavigate(RegionNames.ContentRegion, "ResetPassword");
        }

        private async void Save()
        {
            IsBusy = true;

            var acountResult = await _accountService.UpdateAcount(Account.ToDTO());

            var userSettings = new UserSettingsModel
            {
                DisabledDepartments = Account.UserSettings.SubscribedDepartments.Where(x => !x.IsEnabled).Select(x => x.Id).ToArray()
            };

            var acountSettingsResult = await _accountService.UpdateAcountSettings(userSettings);

            if (acountResult.Succeeded && acountSettingsResult.Succeeded)
            {
                // show 'successfully saved' message
                RegionManager.RequestNavigate(RegionNames.ContentRegion, "ViewNotification"); // temporary solution
            }
            else
            {
                // show 'failed to save' message
            }

            IsBusy = false;
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var acountResult = await _accountService.GetAcount();
            var acountSettingsResult = await _accountService.GetAcountSettings();
            var departmentResult = await _departmentService.GetAll();

            if (!acountResult.Succeeded || !acountSettingsResult.Succeeded || !departmentResult.Succeeded)
            {
                return;
            }

            Account = new AccountVModel(acountResult.Data);
            AllDepartments = departmentResult.Data.Select(x => new DepartmentVModel(x)).ToObservable();
            Account.UserSettings = new UserSettingsVModel(acountSettingsResult.Data);

            Account.UserSettings.SubscribedDepartments = GetSubscribedDepartments(departmentResult.Data, acountSettingsResult.Data.DisabledDepartments).ToObservable();
        }

        private IEnumerable<SubscribedDepartment> GetSubscribedDepartments(IEnumerable<DTO.Acount.DepartmentModel> allDepartments, int[] disabledDepartments)
        {
            foreach (var department in allDepartments)
            {
                var isDisabled = disabledDepartments.Any(x => x == department.Id);

                var sd = new SubscribedDepartment { Id = department.Id, Name = department.Name, IsEnabled = !isDisabled };

                yield return sd;
            }
        }
    }
}
