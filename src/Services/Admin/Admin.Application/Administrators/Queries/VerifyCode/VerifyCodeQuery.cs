
namespace Admin.Application.Administrators.Queries.VerifyCode;

public record VerifyCodeQuery(Email Email, string Code)
    : IQuery<VerifyCodeResult>;

public record VerifyCodeResult(VerifyCodeDto VerifyDto);

