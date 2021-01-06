using NS.DTO.Acount;
using System.Threading.Tasks;

namespace NS.Client.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Result> Login(string sername, string password);
        Task<Result> Logout();
        Task<Result<UserModel>> GetAcount();
        Task<Result<UserModel>> UpdateAcount(UserModel userModel);
        Task<Result<UserSettingsModel>> GetAcountSettings();
        Task<Result<UserSettingsModel>> UpdateAcountSettings(UserSettingsModel userSettings);
    }
}