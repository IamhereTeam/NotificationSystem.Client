using NS.DTO.Acount;
using System.Threading.Tasks;
using NS.Client.Services.Interfaces;

namespace NS.Client.Services.Mock
{
    public class MockAccountService : IAccountService
    {
        public Task<Result> Login(string username, string password)
        {
            return Task.FromResult(new Result().Succeed());
        }

        public Task<Result> Logout()
        {
            return Task.FromResult(new Result().Succeed());
        }

        public Task<Result<UserModel>> GetAcount()
        {
            var userModel = new UserModel
            {
                Id = 10,
                FirstName = "Elon",
                LastName = "Musk",
                Username = "elon",
                DepartmentId = 5,
                Department = new DepartmentModel { Id = 5, Name = "Management" }
            };

            return Task.FromResult(new Result<UserModel>().Succeed(userModel));
        }

        public Task<Result<UserModel>> UpdateAcount(UserModel userModel)
        {
            return Task.FromResult(new Result<UserModel>().Succeed(userModel));
        }

        public Task<Result<UserSettingsModel>> GetAcountSettings()
        {
            var userSettingsModel = new UserSettingsModel
            {
                DisabledDepartments = new int[] { 1 },
            };

            return Task.FromResult(new Result<UserSettingsModel>().Succeed(userSettingsModel));
        }

        public Task<Result<UserSettingsModel>> UpdateAcountSettings(UserSettingsModel userSettings)
        {
            return Task.FromResult(new Result<UserSettingsModel>().Succeed(userSettings));
        }
    }
}