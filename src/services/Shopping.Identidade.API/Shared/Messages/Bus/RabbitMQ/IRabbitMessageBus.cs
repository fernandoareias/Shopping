
using Shopping.Identidade.API.Shared.Integration;
using System;
using System.Threading.Tasks;

namespace Shopping.Identidade.API.Shared.Messages.Bus
{
    internal interface IRabbitMessageBus : IDisposable
    {
        Task<bool> Publisher(Event evento);

    }
}
