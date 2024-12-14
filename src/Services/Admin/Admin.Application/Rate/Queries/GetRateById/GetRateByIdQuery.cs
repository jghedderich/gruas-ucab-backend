namespace Admin.Application.Rates.Queries.GetRateById;

public record GetRateByIdQuery(Guid Id) : IQuery<GetRateByIdResult>;

public record GetRateByIdResult(RateDto Rate);
