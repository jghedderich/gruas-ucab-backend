using Admin.Application.Dtos;

namespace Admin.Application.Rates.Commands.UpdateRate;

public record UpdateRateCommand(RateDto Rate)
    : ICommand<UpdateRateResult>;

public record UpdateRateResult(bool IsSuccess);

public class UpdateRateCommandValidator : AbstractValidator<UpdateRateCommand>
{
    public UpdateRateCommandValidator()
    {
        RuleFor(x => x.Rate.Id).NotEmpty().WithMessage("Id es reuqrido");
        RuleFor(x => x.Rate.RateName).NotEmpty().WithMessage("Rate name es reuqrido");
        RuleFor(x => x.Rate.RateDescription).NotEmpty().WithMessage("Rate description es reuqrido");
        RuleFor(x => x.Rate.CoverageRadius).GreaterThan(0).WithMessage("Coverage radius must be greater than 0");
        RuleFor(x => x.Rate.ExtraPricePerKm).GreaterThanOrEqualTo(0).WithMessage("Extra price per km no puede ser negativo");
    }
}
