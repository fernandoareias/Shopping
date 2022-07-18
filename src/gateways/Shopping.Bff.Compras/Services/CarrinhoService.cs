using System;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Shopping.Bff.Compras.Extensions;

namespace Shopping.Bff.Compras.Services
{
    public interface ICarrinhoService
    {
    }

    public class CarrinhoService : Service, ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }
    }
}