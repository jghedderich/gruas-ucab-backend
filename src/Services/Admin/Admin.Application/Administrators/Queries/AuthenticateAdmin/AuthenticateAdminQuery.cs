namespace Admin.Application.Administrators.Queries.AuthenticateAdmin;

public record AuthenticateAdminQuery(Email Email, Password Password)
    : IQuery<AuthenticateAdminResult>;

public record AuthenticateAdminResult(AdministratorDto Administrator);