using NS.DTO.Notification;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NS.Client.Services.Interfaces
{
    public interface INotificationService
    {
        Task<Result<IEnumerable<UserNotificationModel>>> GetAll();
        Task<Result<CreateNotificationModel>> Create(CreateNotificationModel newNotificationModel);
    }
}
