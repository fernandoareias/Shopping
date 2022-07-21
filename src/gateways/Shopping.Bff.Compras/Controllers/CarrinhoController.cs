using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Bff.Compras.Models;
using Shopping.Bff.Compras.Services;
using Shopping.Core.WebAPI.Controllers;

namespace Shopping.Bff.Compras.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        
        private readonly ICarrinhoService _carrinhoService;
        private readonly ICatalogoService _catalogoService;
        private readonly IPedidoService _pedidoService;

        public CarrinhoController(ICarrinhoService carrinhoService, ICatalogoService catalogoService, IPedidoService pedidoService)
        {
            _carrinhoService = carrinhoService;
            _catalogoService = catalogoService;
            _pedidoService = pedidoService;
        }

        [HttpGet]
        [Route("compras/carrinho")]
        public async Task<IActionResult> Index()
        {
            return CustomResponse(await _carrinhoService.ObterCarrinho());
        }

        [HttpGet]
        [Route("compras/carrinho-quantidade")]
        public async Task<int> ObterQuantidadeCarrinho()
        {
            var carrinho = await _carrinhoService.ObterCarrinho();
            return carrinho?.Itens.Sum(s => s.Quantidade) ?? 0;
        }

        [HttpPost]
        [Route("compras/carrinho/items")]
        public async Task<IActionResult> AdicionarItemCarrinho(ItemCarrinhoDto item)
        {
            var produto = await _catalogoService.ObterPorId(item.ProdutoId);

            await ValidarItemCarrinho(produto, item.Quantidade);

            if (!OperacaoValida())
                return CustomResponse();

            item.Nome = produto.Nome;
            item.Valor = produto.Valor;
            item.Imagem = produto.Imagem;

            var resposta = await _carrinhoService.AdicionarItemCarrinho(item);
            
            return CustomResponse(resposta);
        }

        [HttpPut]
        [Route("compras/carrinho/items/{produtoId}")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDto item)
        {
            var produto = await _catalogoService.ObterPorId(item.ProdutoId);

            await ValidarItemCarrinho(produto, item.Quantidade);

            if (!OperacaoValida())
                return CustomResponse();

            item.Nome = produto.Nome;
            item.Valor = produto.Valor;
            item.Imagem = produto.Imagem;

            var resposta = await _carrinhoService.AtualizarItemCarrinho(produtoId, item);
            
            return CustomResponse(resposta);
        }

        [HttpDelete]
        [Route("compras/carrinho/items/{produtoId}")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var produto = await _catalogoService.ObterPorId(produtoId);

            if (produto == null)
            {
                AdicionarErroProcessamento("Produto inexistente");
                return CustomResponse();
            }

            var resposta = await _carrinhoService.RemoverItemCarrinho(produtoId);
            
            return CustomResponse(resposta);
        }
        
        
        [HttpPost]
        [Route("compras/carrinho/aplicar-voucher")]
        public async Task<IActionResult> AplicarVoucher([FromBody] string voucherCodigo)
        {
            var voucher = await _pedidoService.ObterVoucherPorCodigo(voucherCodigo);

            if(voucher is null)
            {
                AdicionarErroProcessamento("Voucher inválido ou inexistente!");
                return CustomResponse();
            }

            var response = await _carrinhoService.AplicarVoucherCarrinho(voucher);

            return CustomResponse(response);
        }

        
        #region Validação

        private async Task ValidarItemCarrinho(ItemProdutoDto produto, int quantidade)
        {
            if(produto == null)
                AdicionarErroProcessamento("Produto inexistente");
            
            if(quantidade < 1)
                AdicionarErroProcessamento($"Escolha ao menos uma unidade do produto {produto.Nome}");

            var carrinho = await _carrinhoService.ObterCarrinho();
            var itemCarrinho = carrinho.Itens.FirstOrDefault(f => f.ProdutoId == produto.Id);

            if (itemCarrinho != null && itemCarrinho.Quantidade + quantidade > produto.QuantidadeEstoque)
            {
                AdicionarErroProcessamento($"O produto {produto.Nome} possui {produto.QuantidadeEstoque} unidades em estoque, você selecionou {quantidade}");
                return;
            }
            
            if(quantidade > produto.QuantidadeEstoque)
                AdicionarErroProcessamento($"O produto {produto.Nome} possui {produto.QuantidadeEstoque} unidades, você selecinou {quantidade}");

        }
        #endregion
    }
}
