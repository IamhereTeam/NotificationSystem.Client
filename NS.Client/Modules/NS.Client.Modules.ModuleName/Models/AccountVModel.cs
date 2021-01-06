using Prism.Mvvm;
using NS.DTO.Acount;

namespace NS.Client.Modules.ModuleName.Models
{
    public class AccountVModel : BindableBase
    {
        public AccountVModel(UserModel user)
        {
            if (user == null) return;

            Id = user.Id;
            DepartmentId= user.DepartmentId;
            Username = user.Username;
            FirstName = user.FirstName;
            LastName= user.LastName;

            Department = new DepartmentVModel(user.Department);
        }

        public UserModel ToDTO()
        {
            var userModel = new UserModel
            {
                Id = this.Id,
                DepartmentId = this.DepartmentId,
                Username = this.Username,
                FirstName = this.FirstName,
                LastName = this.LastName
            };
            return userModel;
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private int _departmentId;
        public int DepartmentId
        {
            get { return _departmentId; }
            set { SetProperty(ref _departmentId, value); }
        }

        private DepartmentVModel _department;
        public DepartmentVModel Department
        {
            get { return _department; }
            set { SetProperty(ref _department, value); }
        }

        private UserSettingsVModel _userSettings;
        public UserSettingsVModel UserSettings
        {
            get { return _userSettings; }
            set { SetProperty(ref _userSettings, value); }
        }
    }
}