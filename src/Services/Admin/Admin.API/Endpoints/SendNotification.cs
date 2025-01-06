using Admin.Infrastructure.Settings;
using FirebaseAdmin.Messaging;

namespace Admin.API.Endpoints;

public record SendNotificationRequest(string DeviceToken, string Title, string Body, string Time);
public record SendNotificationResponse(bool IsSuccess, string? ErrorMessage);

public class SendNotification : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/notifications/send", async (SendNotificationRequest request, IFirebaseMessagingService messagingService) =>
        {

            try
            {
                var message = new Message()
                {
                    Token = request.DeviceToken, // Replace with the device token you get from the Firebase Console
                    Notification = new Notification()
                    {
                        Title = request.Title,
                        Body = request.Body
                    }
                };
                // Send the message
                string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
                Console.WriteLine("Successfully sent message: " + response);
                var response1 = new SendNotificationResponse(true, null);
                return Results.Ok(response1);
            }
            catch (Exception ex)
            {
                var response = new SendNotificationResponse(false, ex.Message);
                return Results.Problem(response.ErrorMessage, statusCode: StatusCodes.Status500InternalServerError);
            }
        })
        .WithName("SendNotification")
        .Produces<SendNotificationResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Send Notification")
        .WithDescription("Send a push notification to a specific device using Firebase.");
    }
}