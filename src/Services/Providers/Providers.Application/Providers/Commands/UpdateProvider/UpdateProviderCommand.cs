
namespace Providers.Application.Providers.Commands.UpdateProvider;

public record UpdateProviderCommand(ProviderDto Provider) 
    : ICommand<UpdateProviderResult>;

public record UpdateProviderResult(bool IsSuccess);

public class UpdateProviderCommandValidator : AbstractValidator<UpdateProviderCommand>
{
    public UpdateProviderCommandValidator()
    {
        RuleFor(x => x.Provider.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Provider.Name.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.Provider.Name.LastName).NotEmpty().WithMessage("Last name is required");
        RuleFor(x => x.Provider.Phone).NotEmpty().WithMessage("Phone is required");
        RuleFor(x => x.Provider.Dni.Number).NotEmpty().WithMessage("Dni number is required");
    }
}
