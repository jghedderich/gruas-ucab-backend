using Providers.Domain.ValueObjects;

namespace Providers.Application.Dtos;

public record DniDto(DniType Type, string Number);
