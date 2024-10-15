using System.Text.RegularExpressions;

namespace Providers.Domain.ValueObjects
{
    public record RIF
    {
        private const string RifPattern = @"^[A-Z]-\d{8}-\d$";
        public string Rif { get; } = default!;

        private RIF(string rif) => Rif = rif;

        public static RIF Of(string rif)
        {
            if (string.IsNullOrWhiteSpace(rif))
            {
                throw new ArgumentException("RIF cannot be null or whitespace.", nameof(rif));
            }

            if (!Regex.IsMatch(rif, RifPattern))
            {
                throw new ArgumentException($"RIF '{rif}' is not in the correct format. Expected format: 'A-00000000-N'.", nameof(rif));
            }

            return new RIF(rif);
        }
    }
}