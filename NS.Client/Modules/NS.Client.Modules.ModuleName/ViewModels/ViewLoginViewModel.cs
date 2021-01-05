using NS.Client.Core.Mvvm;
using NS.Client.Services.Interfaces;
using Prism.Regions;

namespace NS.Client.Modules.ModuleName.ViewModels
{
    public class ViewLoginViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewLoginViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
