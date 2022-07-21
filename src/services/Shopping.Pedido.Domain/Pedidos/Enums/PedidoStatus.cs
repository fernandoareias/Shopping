using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Pedido.Domain.Pedidos.Enums
{
    public enum PedidoStatus
    {
        Autorizado = 1,
        Pago = 2,
        Recusado = 3,
        Entregue = 4,
        Cancelado = 5
    }
}
