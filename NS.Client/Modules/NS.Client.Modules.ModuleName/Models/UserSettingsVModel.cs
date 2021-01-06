using Prism.Mvvm;
using NS.DTO.Acount;
using System.Collections.ObjectModel;

namespace NS.Client.Modules.ModuleName.Models
{
    public class UserSettingsVModel : BindableBase
    {
        public UserSettingsVModel(UserSettingsModel userSettings)
        {
            SubscribedDepartments = new ObservableCollection<SubscribedDepartment>();
        }

        private ObservableCollection<SubscribedDepartment> _subscribedDepartments;
        public ObservableCollection<SubscribedDepartment> SubscribedDepartments
        {
            get { return _subscribedDepartments; }
            set { SetProperty(ref _subscribedDepartments, value); }
        }
    }

    public class SubscribedDepartment : BindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }
    }
}