
using BuildingBlocks.Abstractions;
using System.Runtime.CompilerServices;
using Users.Domain.ValueObjects;

namespace Users.Domain.Entities
{
    public class User(Guid id, Username username, PasswordHash passwordhash) : Aggregate<Guid>
    {
        public Guid ID { get; private set; } = id;
        public Username Username { get; private set; } = username;
        public PasswordHash PasswordHash { get; private set; } = passwordhash;
        public new bool IsActive { get; private set; } = true;
        public new DateTime CreatedAt { get; private set; } = DateTime.Now;

        public void CambiarPassword(PasswordHash newPassword)
        {
            PasswordHash = newPassword;
            AddDomainEvent(new PasswordChangedEvent(this));
        }

        public void Desactivar()
        {
            IsActive = false;
            AddDomainEvent(new UserDeactivatedEvent(this));
        }

        public void Reactivar() 
        {
            IsActive = true;
            AddDomainEvent(new UserActivatedEvent(this));
        }


    }

    public class Admin(Guid id, Username username, PasswordHash passwordhash) : User(id, username, passwordhash)
    {
    }

    public class Operador(Guid id, Username username, PasswordHash passwordhash) : User(id, username, passwordhash)
    {
    }

    public class AdminProveedor(Guid id, Username username, PasswordHash passwordhash) : User(id, username, passwordhash)
    {
    }

    public class Conductor: User
    {
        public required NumeroLicencia NumeroLicencia { get; set; }
        public required NumeroDocumentoCarro NumeroDocumentoCarro { get; set; }
        // Almacenar las imagenes en base64
        public required ImageBase64 ImagenLicencia { get; set; }
        public required ImageBase64 ImagenCarroDocumento { get; set; }
        public Conductor(Guid id, Username username, PasswordHash passwordhash, NumeroLicencia numerolicencia, NumeroDocumentoCarro numerodocumentocarro, ImageBase64 imagenlicencia, 
            ImageBase64 imagencarrodocumento) : base(id, username, passwordhash)
        {
            NumeroLicencia = numerolicencia;
            NumeroDocumentoCarro = numerodocumentocarro;
            ImagenLicencia = imagenlicencia;
            ImagenCarroDocumento = imagencarrodocumento;
        }
    }
}
