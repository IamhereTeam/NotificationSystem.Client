using Moq;
using Xunit;
using Prism.Regions;
using System.Threading.Tasks;
using NS.Client.Services.Interfaces;
using NS.Client.Modules.ModuleName.ViewModels;

namespace NS.Client.Modules.ModuleName.Tests.ViewModels
{
    public class ViewLoginViewModelFixture
    {
        Mock<IAccountService> _messageServiceMock;
        Mock<IRegionManager> _regionManagerMock;
        const string Username = "elon";
        const string Password = "admin";
        const string ValidationMessage = "Username or password is incorrect";

        public ViewLoginViewModelFixture()
        {
            var accountService = new Mock<IAccountService>();
            accountService.Setup(x => x.Login(Username, Password)).Returns(Task.FromResult(new Result().Failed()));
            _messageServiceMock = accountService;

            _regionManagerMock = new Mock<IRegionManager>();
        }

        [Fact]
        public void MessagePropertyValueUpdated()
        {
            var vm = new ViewLoginViewModel(_regionManagerMock.Object, _messageServiceMock.Object);

            _messageServiceMock.Verify(x => x.Login(Username, Password), Times.Once);

            Assert.Equal(ValidationMessage, vm.ValidationMessage);
        }

        [Fact]
        public void MessageINotifyPropertyChangedCalled()
        {
            var vm = new ViewLoginViewModel(_regionManagerMock.Object, _messageServiceMock.Object);
            Assert.PropertyChanged(vm, nameof(vm.ValidationMessage), () => vm.Username = "Changed");
        }
    }
}
