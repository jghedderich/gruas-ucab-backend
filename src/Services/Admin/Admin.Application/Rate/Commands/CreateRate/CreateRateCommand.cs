using FluentValidation;
using Admin.Application.Dtos;
using BuildingBlocks.CQRS;

namespace Admin.Application.Rates.Commands.CreateRate;

public record CreateRateCommand(RateDto Rate)
    : ICommand<CreateRateResult>;

public record CreateRateResult(Guid Id);

public class CreateRateCommandValidator : AbstractValidator<CreateRateCommand>
{
    public CreateRateCommandValidator()
    {
        RuleFor(c => c.Rate.RateName).NotEmpty().WithMessage("Rate Name is required");
        RuleFor(c => c.Rate.RateDescription).NotEmpty().WithMessage("Rate Description is required");
        RuleFor(c => c.Rate.CoverageRadius).GreaterThan(0).WithMessage("Coverage Radius must be greater than 0");
        RuleFor(c => c.Rate.ExtraPricePerKm).GreaterThanOrEqualTo(0).WithMessage("Extra Price per Km must be greater than or equal to 0");
    }
}
