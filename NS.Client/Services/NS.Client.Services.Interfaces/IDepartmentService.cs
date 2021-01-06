using NS.DTO.Acount;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NS.Client.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<Result<IEnumerable<DepartmentModel>>> GetAll();
    }
}
