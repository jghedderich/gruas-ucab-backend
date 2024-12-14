namespace Providers.Application.Providers.Queries.RequestCode;

public record RequestCodeQuery(Email Email, string Type)
    : IQuery<RequestCodeResult>;

public record RequestCodeResult(bool IsSuccess);