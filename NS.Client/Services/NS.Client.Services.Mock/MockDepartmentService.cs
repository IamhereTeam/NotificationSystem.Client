using NS.DTO.Acount;
using System.Threading.Tasks;
using System.Collections.Generic;
using NS.Client.Services.Interfaces;

namespace NS.Client.Services.Mock
{
    public class MockDepartmentService : IDepartmentService
    {
        public Task<Result<IEnumerable<DepartmentModel>>> GetAll()
        {
            var data = new List<DepartmentModel>
            {
                new DepartmentModel { Id = 1, Name = "HR" },
                new DepartmentModel { Id = 2, Name = "Development" },
                new DepartmentModel { Id = 3, Name = "DevOps" },
                new DepartmentModel { Id = 4, Name = "Sales" },
                new DepartmentModel { Id = 5, Name = "Management" }
            };

            return Task.FromResult(new Result<IEnumerable<DepartmentModel>>().Succeed(data));
        }
    }
}