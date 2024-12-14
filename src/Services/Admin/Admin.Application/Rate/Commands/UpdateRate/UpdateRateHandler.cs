using Admin.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Admin.Application.Rates.Commands.UpdateRate;

public class UpdateRateHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateRateCommand, UpdateRateResult>
{
    public async Task<UpdateRateResult> Handle(UpdateRateCommand command, CancellationToken cancellationToken)
    {
        var rateId = command.Rate.Id;
        var rate = await dbContext.Rates
            .FindAsync(new object[] { rateId }, cancellationToken: cancellationToken);

        if (rate == null)
        {
            throw new RateNotFoundException(command.Rate.Id);
        }

        UpdateRateWithNewValues(rate, command.Rate);

        dbContext.Rates.Update(rate);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateRateResult(true);
    }

    public void UpdateRateWithNewValues(Rate rate, RateDto rateDto)
    {

        rate.Update(
            name: rateDto.RateName,
            baseRate: rateDto.BaseRate,
            extraPricePerKm: rateDto.ExtraPricePerKm,
            coverageRadius: rateDto.CoverageRadius,
            description: rateDto.RateDescription);
    }
}
