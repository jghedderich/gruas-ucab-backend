using BuildingBlocks.Exceptions;

namespace Admin.Application.Exceptions;

public class AdministratorNotFoundException(Guid id)
    : NotFoundException("Administrator", id);
