using NS.Client.Services.Interfaces;

namespace NS.Client.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
