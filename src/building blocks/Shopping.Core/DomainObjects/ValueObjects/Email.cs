using Shopping.Core.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Shopping.Core.DomainObjects.ValueObjects
{
    public class Email
    {
        public const int EnderecoMaxLength = 254;
        public const int EnderecoMinLength = 5;

        public string Endereco { get; private set; }

        protected Email(){}

        public Email(string endereco)
        {
            if (!Validar(endereco))
                throw new DomainExceptions("E-mail inválido.");

            Endereco = endereco;
        }

        public static bool Validar(string email)
        {
            var regexEmail = new Regex(@"/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i");
            return regexEmail.IsMatch(email);

        }
    }
}
