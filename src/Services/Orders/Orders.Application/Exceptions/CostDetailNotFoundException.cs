using BuildingBlocks.Exceptions;


namespace Orders.Application.Exceptions;

public class CostDetailNotFoundException(Guid id)
    : NotFoundException("CostDetail", id);
