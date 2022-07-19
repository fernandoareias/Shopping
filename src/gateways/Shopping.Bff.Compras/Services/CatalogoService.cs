using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Shopping.Bff.Compras.Extensions;
using Shopping.Bff.Compras.Models;

namespace Shopping.Bff.Compras.Services
{
    public interface ICatalogoService
    {
        Task<ItemProdutoDto> ObterPorId(Guid id);
    }

    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        }


        public async Task<ItemProdutoDto> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/catalogo/produtos/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<ItemProdutoDto>(response);
        }
        
    }
}