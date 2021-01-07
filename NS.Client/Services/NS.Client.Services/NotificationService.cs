using System.Threading;
using NS.DTO.Notification;
using System.Threading.Tasks;
using System.Collections.Generic;
using NS.Client.Services.Interfaces;

namespace NS.Client.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NSApiClient _apiClient;

        public NotificationService(NSApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<Result<IEnumerable<UserNotificationModel>>> GetAll()
        {
            return _apiClient.GetAsync<IEnumerable<UserNotificationModel>>("api/Notification", CancellationToken.None);
        }

        public Task<Result<CreateNotificationModel>> Create(CreateNotificationModel newNotificationModel)
        {
            return _apiClient.PostAsync<CreateNotificationModel, CreateNotificationModel>("api/Notification", newNotificationModel, CancellationToken.None);
        }
    }
}