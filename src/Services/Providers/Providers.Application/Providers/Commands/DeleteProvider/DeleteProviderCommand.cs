namespace Providers.Application.Providers.Commands.DeleteProvider;

public record DeleteProviderCommand(Guid ProviderId)
    : ICommand<DeleteProviderResult>;

public record DeleteProviderResult(bool IsSuccess);

public class DeleteProviderCommandValidator : AbstractValidator<DeleteProviderCommand>
{
    public DeleteProviderCommandValidator()
    {
        RuleFor(x => x.ProviderId).NotEmpty().WithMessage("ProviderId is required");
    }
}
