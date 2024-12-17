using BuildingBlocks.Exceptions;

namespace Admin.Application.Exceptions;

public class RateNotFoundException(Guid id)
    : NotFoundException("Rate", id);
