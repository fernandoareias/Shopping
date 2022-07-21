using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Carrinho.API.Models
{
    public class Voucher
    {
        public string Codigo { get; set; }
        public decimal? Percentual { get; set; }
        public decimal? ValorDesconto { get; set; }
        public TipoDescontoVoucher TipoDesconto { get; set; }
    }

    public enum TipoDescontoVoucher
    {
        Procentagem = 0,
        Valor = 1
    }
}
