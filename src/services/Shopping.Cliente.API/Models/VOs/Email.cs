using Shopping.Cliente.API.Shared;

namespace Shopping.Cliente.API.Models.VOs
{
    public class Email 
    {
        // EF
        protected Email() { }

        public Email(string endereco)
        {
            Endereco = endereco;
        }

        public string Endereco { get; private set; }

    }
}
