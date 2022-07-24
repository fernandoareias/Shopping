using MediatR;
using Shopping.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Pedido.API.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoRealizadoEvent>
    {
        private readonly IMessageBus _bus;

        public PedidoEventHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(PedidoRealizadoEvent notification, CancellationToken cancellationToken)
        {
            await _bus.PublishAsync(new PedidoRealizadoEvent(notification.PedidoId, notification.ClienteId));
        }
    }
}
