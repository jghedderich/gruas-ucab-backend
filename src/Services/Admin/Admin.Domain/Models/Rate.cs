using System;
using Admin.Domain.Events;
using Admin.Domain.ValueObjects;

namespace Admin.Domain.Models;

public class Rate : Aggregate<Guid>
{
    public RateName Name { get; private set; } = default!;
    public decimal BaseRate { get; private set; }
    public decimal ExtraPricePerKm { get; private set; }
    public decimal CoverageRadius { get; private set; }
    public RateDescription Description { get; private set; } = default!;

    public static Rate Create(
        Guid id,
        RateName name,
        decimal baseRate,
        decimal extraPricePerKm,
        decimal coverageRadius,
        RateDescription description)
    {
        var rate = new Rate
        {
            Id = id,
            Name = name,
            BaseRate = baseRate,
            ExtraPricePerKm = extraPricePerKm,
            CoverageRadius = coverageRadius,
            Description = description
            
        };

        rate.AddDomainEvent(new RateCreatedEvent(rate));

        return rate;
    }

    public void Update(RateName name, decimal baseRate, decimal extraPricePerKm, decimal coverageRadius, RateDescription description)
    {
        Name = name;
        BaseRate = baseRate;
        ExtraPricePerKm = extraPricePerKm;
        CoverageRadius = coverageRadius;
        Description = description;

        AddDomainEvent(new RateUpdatedEvent(this));
    }
}
