namespace Orders.Domain.ValueObjects;

public record OperatorData
{
    public string OperatorName { get; } = default!;
    public string OperatorEmail { get; } = default!;
    public string OperatorNumber { get; } = default!;

    private OperatorData(string operatorName, string operatorEmail, string operatorNumber) 
    { 
        OperatorName = operatorName;
        OperatorEmail = operatorEmail;
        OperatorNumber = operatorNumber;
    }

    public static OperatorData Of(string operatorName, string OperatorEmail, string OperatorNumber)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(operatorName);
        ArgumentException.ThrowIfNullOrWhiteSpace(OperatorEmail);
        ArgumentException.ThrowIfNullOrWhiteSpace(OperatorNumber);

        return new OperatorData(operatorName, OperatorEmail, OperatorNumber);
    }
}
