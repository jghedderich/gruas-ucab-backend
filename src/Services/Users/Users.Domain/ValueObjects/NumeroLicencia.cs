using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Domain.ValueObjects
{
    public class NumeroLicencia
    {
        public string Value { get; private set; }
        private NumeroLicencia(string value)
        {
            if (string.IsNullOrWhiteSpace(value))  
                throw new ArgumentNullException("El numero de licencia no puede estar vacio");
            Value = value;
        }
        public static NumeroLicencia Create(string value) => new NumeroLicencia(value);
        public override string ToString() => Value;
    }
}
