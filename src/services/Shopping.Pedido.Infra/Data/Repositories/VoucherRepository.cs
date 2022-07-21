using Shopping.Core.Data;
using Shopping.Pedido.Domain.Vouchers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Pedido.Infra.Data.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {

        private readonly PedidoContext _context;

        public VoucherRepository(PedidoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
