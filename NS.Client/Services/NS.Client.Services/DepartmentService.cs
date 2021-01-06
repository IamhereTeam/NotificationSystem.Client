using NS.DTO.Acount;
using System.Threading;
using System.Threading.Tasks;
using NS.Client.Services.Interfaces;
using System.Collections.Generic;

namespace NS.Client.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly NSApiClient _apiClient;

        public DepartmentService(NSApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<Result<IEnumerable<DepartmentModel>>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}