using BuildingBlocks.Exceptions;

namespace Orders.Application.Exceptions;

public class OperatorNotFoundException(Guid id)
    : NotFoundException("Operator", id);
