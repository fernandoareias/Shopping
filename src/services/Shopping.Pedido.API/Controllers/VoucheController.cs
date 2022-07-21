using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Core.WebAPI.Controllers;
using Shopping.Pedido.API.Application.DTOs;
using Shopping.Pedido.API.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shopping.Pedido.API.Controllers
{
    [Authorize]
    public class VoucheController : MainController
    {
        private readonly IVoucherQueries _voucherQueries;

        public VoucheController(IVoucherQueries voucherQueries)
        {
            _voucherQueries = voucherQueries;
        }


        [HttpGet("voucher/{codigo}")]
        [ProducesResponseType(typeof(VoucherDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                return NotFound();

            var voucher = await _voucherQueries.ObterVoucherPorCodigo(codigo);

            return voucher == null ? NotFound() : CustomResponse(voucher);
        }
    }
}
