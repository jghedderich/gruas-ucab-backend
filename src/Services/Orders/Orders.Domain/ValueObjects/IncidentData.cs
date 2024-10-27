namespace Orders.Domain.ValueObjects;

public record IncidentData
{
    public DateTime IncidentDate { get; } = default!;
    public string Location { get; } = default!;
    public string IncidentDescription { get; } = default!;

    private IncidentData(DateTime incidentDate, string location, string incidentDescription) 
    {
        IncidentDate = incidentDate;
        Location = location;   
        IncidentDescription = incidentDescription;
    }

    public static IncidentData Of(DateTime incidentDate, string location, string incidentDescription)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(incidentDate.ToString());
        ArgumentException.ThrowIfNullOrWhiteSpace(location);
        ArgumentException.ThrowIfNullOrWhiteSpace(incidentDescription);
        
        return new IncidentData(incidentDate, location, incidentDescription);
    }
}
