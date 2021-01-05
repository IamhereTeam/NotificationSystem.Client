using Prism.Mvvm;

namespace NS.Client.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Notification System Client";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
