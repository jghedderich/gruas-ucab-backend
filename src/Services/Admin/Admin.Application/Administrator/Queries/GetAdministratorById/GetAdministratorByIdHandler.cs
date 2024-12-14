using Admin.Application.Administrators.Queries.GetAdministratorById;
using Admin.Application.Extensions;

namespace Admin.Application.Administrators.Queries.GetAdministratorById;

public class GetAdministratorsHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetAdministratorByIdQuery, GetAdministratorByIdResult>
{
    public async Task<GetAdministratorByIdResult> Handle(GetAdministratorByIdQuery query, CancellationToken cancellationToken)
    {
        var administrator = await dbContext.Administrators
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id.Equals(query.Id), cancellationToken)
            ?? throw new AdministratorNotFoundException(query.Id);

        var administratorDto = administrator.ToAdministratorDto();
        return new GetAdministratorByIdResult(administratorDto);
    }
}
