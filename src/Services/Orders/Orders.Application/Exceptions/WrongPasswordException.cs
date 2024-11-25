using BuildingBlocks.Exceptions;

namespace Orders.Application.Exceptions;

public class WrongPasswordException(Guid Id)
    : BadRequestException($"The password for user with id ${Id} of id is incorrect");
