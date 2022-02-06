using Shopping.Cliente.API.Shared;

namespace Shopping.Cliente.API.Models.VOs
{
    public class Cpf : Entity
    {
        public Cpf(string numero)
        {
            Numero = numero;
        }

        public string Numero { get; private set; }
    }
}
