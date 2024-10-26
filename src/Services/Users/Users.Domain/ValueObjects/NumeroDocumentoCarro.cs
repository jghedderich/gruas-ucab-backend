

namespace Users.Domain.ValueObjects
{
    public class NumeroDocumentoCarro
    {
        public string Value { get; private set; }
        private NumeroDocumentoCarro(string value) 
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("El numero de documento del carro no puede ser vacio");
            Value = value;
        }

        public static NumeroDocumentoCarro Create(string value) => new NumeroDocumentoCarro(value);
        public override string ToString() => Value;
    }
}
