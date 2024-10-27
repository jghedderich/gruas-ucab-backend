
namespace Providers.Application.Dtos
{
    public record DniDto(string Type, string Number)
    {
        public DniType ToDniType()
        {
            if (!Enum.TryParse<DniType>(Type, true, out var dniType))
            {
                throw new ArgumentException($"Invalid DNI type: {Type}");
            }
            return dniType;
        }
    }
}
