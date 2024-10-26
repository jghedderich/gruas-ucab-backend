
namespace Providers.Application.Providers.Commands.CreateProvider;

public record CreateProviderCommand(ProviderDto Provider) 
    : ICommand<CreateProviderResult>;

public record CreateProviderResult(Guid Id);

public class CreateProviderCommandValidator : AbstractValidator<CreateProviderCommand>
{
    public CreateProviderCommandValidator()
    {
        RuleFor(p => p.Provider.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(p => p.Provider.Dni).NotEmpty().WithMessage("Dni is required");
        RuleFor(p => p.Provider.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(p => p.Provider.Phone).NotEmpty().WithMessage("Phone is required");
    }
}
