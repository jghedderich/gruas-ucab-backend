namespace Providers.Application.Providers.Queries.GetProviderById;

public record GetProviderByIdQuery(Guid Id)
    : IQuery<GetProviderByIdResult>;

public record GetProviderByIdResult(ProviderDto Provider);
