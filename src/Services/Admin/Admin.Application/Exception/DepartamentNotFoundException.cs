using BuildingBlocks.Exceptions;

namespace Admin.Application.Exceptions;

public class DepartmentNotFoundException(Guid id)
    : NotFoundException("Department", id);
