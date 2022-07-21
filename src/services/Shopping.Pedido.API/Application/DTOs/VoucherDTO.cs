using Shopping.Pedido.Domain.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Pedido.API.Application.DTOs
{
    public class VoucherDTO
    {
        public string Codigo { get; set; }
        public decimal? Percentual { get; set; }
        public decimal? ValorDesconto { get; set; }
        public int TipoDesconto { get; set; }

        private VoucherDTO()
        {
        }

        public VoucherDTO(Voucher voucher)
        {
            this.Codigo = voucher.Codigo;
            this.Percentual = voucher.Percentual;
            this.ValorDesconto = voucher.ValorDesconto;
            this.TipoDesconto = (int)voucher.TipoDesconto;
        }



    }
}
