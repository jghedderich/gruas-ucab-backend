
namespace Users.Domain.ValueObjects
{
    public class Username
    {
        public string Value { get; private set; }

        private Username(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("El Usuario no puede estar vacio");

            if (value.Length > 10 || value.Length < 20)
                throw new ArgumentException("El Usuario debe tener entre 10 y 20 caracteres");

            Value = value;
        }

        public static Username Create(string value) => new Username(value);

        public override string ToString() => Value;

    }
}
