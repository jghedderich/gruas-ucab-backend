using System;

namespace Admin.Application.Rates.Commands.DeleteRate;

public record DeleteRateCommand(Guid RateId)
    : ICommand<DeleteRateResult>;

public record DeleteRateResult(bool IsSuccess);

public class DeleteRateCommandValidator : AbstractValidator<DeleteRateCommand>
{
    public DeleteRateCommandValidator()
    {
        RuleFor(x => x.RateId).NotEmpty().WithMessage("El ID de la tarifa es requerido");
    }
}
