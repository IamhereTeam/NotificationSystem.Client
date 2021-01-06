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
    }
}