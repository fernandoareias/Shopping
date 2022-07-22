using Microsoft.EntityFrameworkCore;
using Shopping.Core.Data;
using Shopping.Pedido.Domain.Vouchers;
using Shopping.Pedido.Domain.Vouchers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<Voucher> ObterVoucherPorCodigoAsync(string codigo)
        {
            return _context.Voucher.FirstOrDefaultAsync(f => f.Codigo == codigo);
        }

        public void Atualizar(Voucher voucher)
        {
            _context.Voucher.Update(voucher);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
