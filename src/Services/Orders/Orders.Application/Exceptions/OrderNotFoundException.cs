using BuildingBlocks.Exceptions;

namespace Orders.Application.Exceptions;

public class OrderNotFoundException(Guid id)
    : NotFoundException("Order", id);