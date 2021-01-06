using NS.DTO.Acount;
using System.Threading;
using System.Threading.Tasks;
using NS.Client.Services.Interfaces;

namespace NS.Client.Services
{
    public class AccountService : IAccountService
    {
        private readonly NSApiClient _apiClient;

        public AccountService(NSApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<Result> Login(string username, string password)
        {
            return _apiClient.Login(username, password);
        }

        public Task<Result> Logout()
        {
            return _apiClient.Logout();
        }

        public Task<Result<UserModel>> GetAcount()
        {
            return _apiClient.GetAsync<UserModel>("api/Acount", CancellationToken.None);
        }

        public Task<Result<UserSettingsModel>> GetAcountSettings()
        {
            return _apiClient.GetAsync<UserSettingsModel>("api/Acount/Settings", CancellationToken.None);
        }

        public Task<Result<UserModel>> UpdateAcount(UserModel userModel)
        {
            return _apiClient.PostAsync<UserModel, UserModel>("api/Acount/", userModel, CancellationToken.None);
        }

        public Task<Result<UserSettingsModel>> UpdateAcountSettings(UserSettingsModel userSettings)
        {
            return _apiClient.PostAsync<UserSettingsModel, UserSettingsModel>("api/Acount/Settings", userSettings, CancellationToken.None);
        }
    }
}