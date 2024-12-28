
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Providers.Application.Drivers.Commands.UpdateOrderStatus;

public class UpdateOrderStatusHandler(IApplicationDbContext dbContext, IPublishEndpoint publishEndpoint) 
    : ICommandHandler<UpdateOrderStatusCommand, UpdateOrderStatusResult>
{
    public async Task<UpdateOrderStatusResult> Handle(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
    {
        if (command.Order.DriverId != Guid.Empty)
        {

            var driverId = command.Order.DriverId;
            var driver = await dbContext.Drivers
                .FindAsync([driverId], cancellationToken: cancellationToken) ?? throw new DriverNotFoundException(command.Order.DriverId);
                UpdateDriverLocationWithNewValues(driver, command.Order);

                dbContext.Drivers.Update(driver);
                await dbContext.SaveChangesAsync(cancellationToken);
        }

        var eventMessage = new DriverUpdatesOrderEvent
        {
            OrderId = command.Order.Id,
            Status = command.Order.Status
        };

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        return new UpdateOrderStatusResult(command.Order.Id, true);
    }

    public static void UpdateDriverLocationWithNewValues(Driver driver, UpdateOrderStatusDto dto)
    {
        var latitude = dto.Location!.Coordinates.Latitude;
        var longitude = dto.Location!.Coordinates.Longitude;

        driver.UpdateLocation(
            Location.Of(
                dto.Location.Address1, 
                dto.Location.Address2, 
                Coordinates.Of(latitude, longitude), 
                dto.Location.City, 
                dto.Location.State, 
                dto.Location.Zip)
            );
    }
}
