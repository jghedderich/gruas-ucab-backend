
namespace Users.Domain.ValueObjects
{
    public class PasswordHash
    {
        public string Hash { get; private set; }
        private PasswordHash(string hash)
        {
            if (string.IsNullOrEmpty(hash))
                throw new ArgumentNullException("La contraseña no puede estar vacia");
            Hash = hash;
        }

        public static PasswordHash Create(string hash) => new PasswordHash(hash);

        public override string ToString() => Hash;
    }
}
