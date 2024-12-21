using Admin.Infrastructure.Settings;
using FirebaseAdmin.Messaging;

namespace Admin.API.Endpoints;

public record SendNotificationRequest(string DeviceToken, string Title, string Body);
public record SendNotificationResponse(bool IsSuccess, string? ErrorMessage);

public class SendNotification : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        // Create a message
       // var message = new Message()
       // {
         //   Token = "773576465708-60rikb1viqdgfgcipvka4tluct1po87s.apps.googleusercontent.com", // Replace with the device token you get from the Firebase Console
          //  Notification = new Notification()
           // {
            //    Title = "Test Notification",
            //    Body = "This is a test notification."
           // }
     //   };

        // Send the message
        // string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
        // Console.WriteLine("Successfully sent message: " + response);

        app.MapPost("/notifications/send", async (SendNotificationRequest request, IFirebaseMessagingService messagingService) =>
        {

            try
            {
                await messagingService.SendPushNotificationAsync(request.DeviceToken, request.Title, request.Body);
                var response = new SendNotificationResponse(true, null);
                return Results.Ok(response);
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