using Admin.Application.Extensions;
using Admin.Application.Rates.Queries.GetRates;
namespace Admin.Application.Rates.Queries.GetRateById;

public class GetRateByIdHandler : IQueryHandler<GetRateByIdQuery, GetRateByIdResult>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly ILogger<GetRateByIdHandler> _logger;

    public GetRateByIdHandler(IApplicationDbContext dbContext, ILogger<GetRateByIdHandler> logger)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<GetRateByIdResult> Handle(GetRateByIdQuery query, CancellationToken cancellationToken)
    {
        if (query.Id == Guid.Empty)
            throw new ArgumentException("The provided rate ID cannot be empty.", nameof(query.Id));

        var rate = await _dbContext.Rates
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == query.Id, cancellationToken);

        if (rate == null)
        {
            _logger.LogWarning("Rate with ID {RateId} was not found.", query.Id);
            throw new RateNotFoundException(query.Id);
        }

        return new GetRateByIdResult(rate.ToRateDto());
    }
}
