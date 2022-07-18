using System.Threading.Tasks;

namespace Shopping.Carrinho.API.Models.Interfaces
{
    public interface ICarrinhoRepository
    {
        Task<CarrinhoCliente> GetAll();
        Task<CarrinhoCliente> GetById();
    }
}