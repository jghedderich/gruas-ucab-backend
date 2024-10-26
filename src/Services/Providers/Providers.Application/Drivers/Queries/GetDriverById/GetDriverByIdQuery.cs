namespace Providers.Application.Drivers.Queries.GetDriverById;

public record GetDriverByIdQuery(Guid Id)
    : IQuery<GetDriverByIdResult>;

public record GetDriverByIdResult(DriverDto Driver);
