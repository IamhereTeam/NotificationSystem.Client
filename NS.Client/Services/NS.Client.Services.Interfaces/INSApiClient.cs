using NS.DTO.Acount;
using System.Threading;
using System.Threading.Tasks;

namespace NS.Client.Services.Interfaces
{
    public interface INSApiClient
    {
        Task<Result> Login(string username, string password);
        Task<Result> Logout();
        Task<Result<Tout>> GetAsync<Tout>(string requestUri, CancellationToken cancellationToken);
        Task<Result<Tout>> PostAsync<Tin, Tout>(string requestUri, Tin data, CancellationToken cancellationToken);
        Task<Result<Tout>> PutAsync<Tin, Tout>(string requestUri, Tin data, CancellationToken cancellationToken);
    }
}