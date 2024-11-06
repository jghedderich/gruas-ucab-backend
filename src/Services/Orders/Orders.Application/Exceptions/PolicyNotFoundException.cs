using BuildingBlocks.Exceptions;

namespace Orders.Application.Exceptions;

public class PolicyNotFoundException(Guid id)
    : NotFoundException("Policy", id);