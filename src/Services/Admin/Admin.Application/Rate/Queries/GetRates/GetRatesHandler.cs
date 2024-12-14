using BuildingBlocks.Pagination;
using BuildingBlocks.CQRS;
using Admin.Application.Extensions;
using Admin.Application.Dtos;

namespace Admin.Application.Rates.Queries.GetRates
{
    public class GetRatesHandler(IApplicationDbContext dbContext) : IQueryHandler<GetRatesQuery, GetRatesResult>
    {
     
        public async Task<GetRatesResult> Handle(GetRatesQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            
            var totalCount = await dbContext.Rates.LongCountAsync(cancellationToken);

          
            var rates = await dbContext.Rates
                .AsNoTracking()
                .OrderBy(r => r.Name) 
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

           
            var ratesDto = rates.Select(rate => rate.ToRateDto());

  
            return new GetRatesResult(
               new PaginatedResult<RateDto>(pageIndex, pageSize, totalCount, ratesDto)
           );
            
        }
    }
}
