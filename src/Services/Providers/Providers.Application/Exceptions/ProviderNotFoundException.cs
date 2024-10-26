using BuildingBlocks.Exceptions;

namespace Providers.Application.Exceptions;

public class ProviderNotFoundException(Guid id) 
    : NotFoundException("Provider", id);
