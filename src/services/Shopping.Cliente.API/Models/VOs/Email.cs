using Shopping.Cliente.API.Shared;

namespace Shopping.Cliente.API.Models.VOs
{
    public class Email : Entity
    {
        // EF
        protected Email() { }

        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }

    }
}
