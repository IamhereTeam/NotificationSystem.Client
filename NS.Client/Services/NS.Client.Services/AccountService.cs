using NS.DTO.Acount;
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
    }
}