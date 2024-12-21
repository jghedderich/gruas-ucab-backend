
using FirebaseAdmin.Messaging;

namespace Admin.Infrastructure.Settings;

public interface IFirebaseMessagingClient
{
    Task<string> SendAsync(Message message);
}

public class FirebaseMessagingClient : IFirebaseMessagingClient
{
    public async Task<string> SendAsync(Message message)
    {
        return await FirebaseMessaging.DefaultInstance.SendAsync(message);
    }
}
