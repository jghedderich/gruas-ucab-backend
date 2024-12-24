
using BuildingBlocks.Caching;
using BuildingBlocks.Exceptions;
using BuildingBlocks.Emails;

namespace Admin.Application.Administrators.Queries.RequestCode;

public class RequestCodeHandler(IApplicationDbContext dbContext, IEmailSender emailSender, IRedisCacheService redisCache)
    : IQueryHandler<RequestCodeQuery, RequestCodeResult>
{
    public async Task<RequestCodeResult> Handle(RequestCodeQuery query, CancellationToken cancellationToken)
    {
        var code = new Random().Next(0, (int)Math.Pow(10, 6)).ToString().PadLeft(6, '0');

        if (query.Type == "administrators")
        {
            var admin = await dbContext.Administrators
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Email.Equals(query.Email), cancellationToken)
                ?? throw new NotFoundException($"Admin with email {query.Email} was not found");

            var codeDto = new RequestCodeDto(Id: admin.Id, Code: code, Email: admin.Email.Value);

            await emailSender.SendEmailAsync(admin.Email.Value, "Su código de recuperacion", code);

            redisCache.SetData($"code_{codeDto.Code}", codeDto);

        }else
        {
            throw new BadRequestException("The type provided is invalid");
        }

        return new RequestCodeResult(true);
    }
}
