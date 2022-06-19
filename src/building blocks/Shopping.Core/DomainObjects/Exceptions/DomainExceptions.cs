using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.DomainObjects.Exceptions
{
    public class DomainExceptions : Exception
    {
        public DomainExceptions()
        {

        }

        public DomainExceptions(string message) : base(message)
        {

        }

        public DomainExceptions(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
