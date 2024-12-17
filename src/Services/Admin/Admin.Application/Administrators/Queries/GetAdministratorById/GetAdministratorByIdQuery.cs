namespace Admin.Application.Administrators.Queries.GetAdministratorById;

public record GetAdministratorByIdQuery(Guid Id)
    : IQuery<GetAdministratorByIdResult>;

public record GetAdministratorByIdResult(AdministratorDto Administrator);

