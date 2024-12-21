
using FirebaseAdmin.Messaging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Admin.Infrastructure.Settings;

public interface IFirebaseMessagingService
{
    Task SendPushNotificationAsync(string deviceToken, string? messageTitle, string? messageBody);
}

public class FirebaseMessagingService : IFirebaseMessagingService
{
    private readonly ILogger<FirebaseMessagingService> _logger;
    private readonly FirebaseMessagingSettings _firebaseMessagingSettings;
    private readonly IFirebaseMessagingClient _firebaseMessagingClient;
    private readonly IFirebaseAppClient _firebaseAppClient;

    public FirebaseMessagingService(
        ILogger<FirebaseMessagingService> logger,
        IOptions<FirebaseMessagingSettings> firebaseMessagingSettings,
        IFirebaseMessagingClient firebaseMessagingClient,
        IFirebaseAppClient firebaseAppClient)
    {
        _logger = logger;
        _firebaseMessagingSettings = firebaseMessagingSettings.Value;
        _firebaseMessagingClient = firebaseMessagingClient;
        _firebaseAppClient = firebaseAppClient;
    }


    public async Task SendPushNotificationAsync(string deviceToken, string? messageTitle, string? messageBody)
    {
        try
        {
            _logger.LogInformation("FirebaseMessagingService.SendPushNotificationAsync  {Object}", deviceToken);

            _firebaseAppClient.CreateFirebaseApp();

            var message = new Message()
            {
                Token = deviceToken, // FCM device registration token
                Notification = new Notification() { Title = messageTitle, Body = messageBody },
                Android = new AndroidConfig()
                {
                    Priority = Priority.High,
                    Notification = new AndroidNotification()
                    {
                        Title = messageTitle,
                        Body = messageBody,
                        Priority = NotificationPriority.HIGH,
                        Sound = _firebaseMessagingSettings.MessageSound,
                        DefaultSound = false,
                        ChannelId = _firebaseMessagingSettings.ChannelId
                    }
                }
            };

            await _firebaseMessagingClient.SendAsync(message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error SendPushNotificationAsync. {Message}", ex.Message);
        }
    }
}
