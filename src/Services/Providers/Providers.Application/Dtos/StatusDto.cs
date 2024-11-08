namespace Providers.Application.Dtos
{
    public record StatusDto(string Status)
    {
        public StatusType ToStatusType()
        {
            if (!Enum.TryParse<StatusType>(Status, true, out var status))
            {
                throw new ArgumentException($"Invalid Status type: {Status}");
            }
            return status;
        }
    }
}
