using Admin.Domain.ValueObjects;

namespace Admin.Application.Dtos;

public record RateDto(
    Guid Id,
    RateName RateName,
    RateDescription RateDescription,
    decimal BaseRate,
    decimal CoverageRadius,      
    decimal ExtraPricePerKm);   
