using Admin.Application.Dtos;
using BuildingBlocks.CQRS;
using System.Threading.Tasks;
using System.Threading;

namespace Admin.Application.Rates.Commands.CreateRate;

public class CreateRateHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateRateCommand, CreateRateResult>
{
    public async Task<CreateRateResult> Handle(CreateRateCommand command, CancellationToken cancellationToken)
    {
        var rate = CreateNewRate(command.Rate);

        dbContext.Rates.Add(rate);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateRateResult(rate.Id);
    }

    private static Rate CreateNewRate(RateDto rateDto)
    {
        var newRate = Rate.Create(
            id: Guid.NewGuid(),
            name: rateDto.RateName,           
            baseRate: rateDto.BaseRate,       
            extraPricePerKm: rateDto.ExtraPricePerKm, 
            coverageRadius: rateDto.CoverageRadius, 
            description: rateDto.RateDescription 
        );

        return newRate;
    }
}
