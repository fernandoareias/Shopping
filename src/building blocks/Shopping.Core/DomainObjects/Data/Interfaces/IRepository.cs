using Shopping.Core.DomainObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.DomainObjects.Data.Interfaces
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
    }
}
