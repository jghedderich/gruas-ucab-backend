using BuildingBlocks.Caching;
using BuildingBlocks.Exceptions;

namespace Orders.Application.Operators.Queries.VerifyCode;

public class VerifyCodeHandler(IRedisCacheService redisCacheService) :
    IQueryHandler<VerifyCodeQuery, VerifyCodeResult>

{
    public async Task<VerifyCodeResult> Handle(VerifyCodeQuery query, CancellationToken cancellationToken)
    {
        var cachingKey = $"code_{query.Code}";
        var data = redisCacheService.GetData<VerifyCodeDto>(cachingKey)
            ?? throw new NotFoundException("The code submitted is incorrect");

        redisCacheService.DeleteData(cachingKey);

        var verifyDto = new VerifyCodeDto(IsSuccess: true, Id: data.Id);

        return new VerifyCodeResult(verifyDto);
    }
}
