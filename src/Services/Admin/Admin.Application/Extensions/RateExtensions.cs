using Admin.Application.Dtos;
using Admin.Domain.Models;

namespace Admin.Application.Extensions;

public static class RateExtensions
{
    public static IEnumerable<RateDto> ToRateDtoList(this IEnumerable<Rate> rates)
    {
        return rates.Select(r => new RateDto(
            Id: r.Id,
            RateName: RateName.Create(r.Name.Value),  // Utilizando el método Create de RateName
            RateDescription: RateDescription.Create(r.Description.Value),  // Utilizando el método Create de RateDescription
            CoverageRadius: r.CoverageRadius,
            ExtraPricePerKm: r.ExtraPricePerKm,
            BaseRate: r.BaseRate
        ));
    }

    public static RateDto ToRateDto(this Rate rate)
    {
        return DtoFromRate(rate);
    }

    private static RateDto DtoFromRate(Rate rate)
    {
        return new RateDto(
            Id: rate.Id,
            RateName: RateName.Create(rate.Name.Value),  // Utilizando el método Create de RateName
            RateDescription: RateDescription.Create(rate.Description.Value),  // Utilizando el método Create de RateDescription
            CoverageRadius: rate.CoverageRadius,
            ExtraPricePerKm: rate.ExtraPricePerKm,
            BaseRate: rate.BaseRate
        );
    }
}

