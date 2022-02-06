using Shopping.Cliente.API.Shared;

namespace Shopping.Cliente.API.Models.VOs
{
    public class Cpf 
    {
        public Cpf(string numero)
        {
            Numero = numero;
        }

        public string Numero { get; private set; }
    }
}
