using Prism.Mvvm;
using NS.DTO.Acount;

namespace NS.Client.Modules.ModuleName.Models
{
    public class DepartmentVModel : BindableBase
    {
        public DepartmentVModel(DepartmentModel department)
        {
            if (department == null) return;

            Id = department.Id;
            Name = department.Name;
        }

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
    }
}