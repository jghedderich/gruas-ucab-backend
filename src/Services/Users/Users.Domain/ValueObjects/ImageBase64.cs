

namespace Users.Domain.ValueObjects
{
    public class ImageBase64
    {
        public string Value { get; private set; }
        private ImageBase64(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Debe subir los documentos");
            Value = value;
        }
        public static ImageBase64 Create(string value) => new ImageBase64(value);
        public override string ToString() => Value;
    }
}
