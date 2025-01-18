using System.Diagnostics.CodeAnalysis;
using BuildingBlocks.Caching;
using BuildingBlocks.Emails;
using BuildingBlocks.Exceptions;

namespace Providers.Application.Providers.Queries.RequestCode;

[ExcludeFromCodeCoverage]
public class RequestCodeHandler(IApplicationDbContext dbContext, IEmailSender emailSender, IRedisCacheService redisCache)
    : IQueryHandler<RequestCodeQuery, RequestCodeResult>
{
    public async Task<RequestCodeResult> Handle(RequestCodeQuery query, CancellationToken cancellationToken)
    {
        var code = new Random().Next(0, (int)Math.Pow(10, 6)).ToString().PadLeft(6, '0');

        if (query.Type == "providers")
        {
            Provider provider = await dbContext.Providers
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Email.Equals(query.Email), cancellationToken)
                ?? throw new NotFoundException($"Provider with email {query.Email} was not found");

            var codeDto = new RequestCodeDto(Id: provider.Id, Code: code, Email: provider.Email.Value);

            await emailSender.SendEmailAsync(provider.Email.Value, "Su código de recuperacion", code);
            
            redisCache.SetData($"code_{codeDto.Code}", codeDto);

        } else if (query.Type == "drivers")
        {
            Driver driver = await dbContext.Drivers
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Email.Equals(query.Email), cancellationToken)
                ?? throw new NotFoundException($"Driver with email {query.Email} was not found");
            
            var codeDto = new RequestCodeDto(Id: driver.Id, Code: code, Email: driver.Email.Value);

            await emailSender.SendEmailAsync(driver.Email.Value, "Su código de recuperacion", code);

            redisCache.SetData($"code_{codeDto.Code}", codeDto);
        } else
        {
            throw new BadRequestException("The type provided is invalid");
        }

        return new RequestCodeResult(true);
    }
}