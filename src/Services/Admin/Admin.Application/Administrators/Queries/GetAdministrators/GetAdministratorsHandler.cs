using BuildingBlocks.Pagination;
using Admin.Application.Extensions;

namespace Admin.Application.Administrators.Queries.GetAdministrators;

public class GetAdministratorsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetAdministratorsQuery, GetAdministratorsResult>
{
    public async Task<GetAdministratorsResult> Handle(GetAdministratorsQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Administrators.LongCountAsync(cancellationToken);

        var administrators = await dbContext.Administrators
            .OrderBy(a => a.Name.FirstName)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetAdministratorsResult(
            new PaginatedResult<AdministratorDto>(pageIndex, pageSize, totalCount, administrators.ToAdministratorDtoList())
        );
    }
}
