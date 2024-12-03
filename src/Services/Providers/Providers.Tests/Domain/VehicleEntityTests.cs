
using FluentAssertions;
using Providers.Domain.Events;
using Providers.Domain.Models;
using Providers.Domain.ValueObjects;

namespace Providers.Tests.Domain;

public class VehicleEntityTests
{
    
    private readonly Vehicle _vehicle;

    public VehicleEntityTests()
    {
        Guid id = Guid.NewGuid();
        Guid providerId = Guid.NewGuid();
        VehicleType type = VehicleType.Medium;
        Brand brand = Brand.Of("Zusuki");
        Model model = Model.Of("Lancer");
        int year = 2002;

        _vehicle = Vehicle.Create(id, providerId, type, brand, model, year);
    }

    [Fact]
    public void Vehicle_Create_CreatesNewVehicle()
    {
        // assert
        _vehicle.Brand.Should().Be(_vehicle.Brand);
        _vehicle.Year.Should().Be(_vehicle.Year);

        _vehicle.DomainEvents.Should().ContainSingle(e => e is VehicleCreatedEvent);
    }

    [Fact]
    public void Vehicle_Upate_UpdatesVehicle()
    {
        // arrange
        Model NewModel = Model.Of("Grand Vitara");
        int NewYear = 2012;

        // act
        _vehicle.Update(_vehicle.Type, _vehicle.Brand, NewModel, NewYear);

        // assert
        _vehicle.Model.Should().Be(NewModel);
        _vehicle.Year.Should().Be(NewYear);

        _vehicle.DomainEvents.Should().ContainSingle(e => e is VehicleUpdatedEvent);
    }
}
