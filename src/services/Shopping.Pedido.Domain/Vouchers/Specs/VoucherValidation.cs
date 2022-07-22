using NetDevPack.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Pedido.Domain.Vouchers.Specs
{
    public class VoucherValidation : SpecValidator<Voucher>
    {
        public VoucherValidation()
        {
            var dataspec = new VoucherDataSpecification();
            var ativospec = new VoucherAtivoSpecification();
            var quantidadespec = new VoucherQuantidadeSpecification();


            Add("dataSpec", new Rule<Voucher>(dataspec, "Esse voucher está expirado."));
            Add("ativoSpec", new Rule<Voucher>(ativospec, "Esse voucher desativado."));
            Add("quantidadeSpec", new Rule<Voucher>(quantidadespec, "Esse voucher já foi utilizado."));
        }
    }
}
