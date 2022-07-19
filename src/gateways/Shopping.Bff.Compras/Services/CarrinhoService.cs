using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Shopping.Bff.Compras.Extensions;
using Shopping.Bff.Compras.Models;
using Shopping.Core.Communication;

namespace Shopping.Bff.Compras.Services
{
    public interface ICarrinhoService
    {
        Task<CarrinhoDto> ObterCarrinho();
        Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoDto produto);
        Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDto carrinho);
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
    }

    public class CarrinhoService : Service, ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }

        public async Task<CarrinhoDto> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/carrinho");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<CarrinhoDto>(response);
        }
        
        public async Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoDto produto)
        {
            var itemContent = ObterConteudo(produto);
            
            var response = await _httpClient.PostAsync("/carrinho", itemContent);

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }

        public async Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDto carrinho)
        {
            var itemContent = ObterConteudo(carrinho);
            
            var response = await _httpClient.PutAsync($"/carrinho/{carrinho.ProdutoId}", itemContent);

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }

        public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/carrinho/{produtoId}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }
    }
}