using BuildingBlocks.Exceptions;

namespace Providers.Application.Exceptions;

public class DriverNotFoundException(Guid id)
    : NotFoundException("Driver", id);
