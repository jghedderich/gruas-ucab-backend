using BuildingBlocks.Exceptions;

namespace Providers.Application.Exceptions;

public class VehicleNotFoundException(Guid id) : NotFoundException("Vehicle", id);