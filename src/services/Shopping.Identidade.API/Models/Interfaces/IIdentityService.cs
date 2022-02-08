using Shopping.Identidade.API.Shared.Responses;
using System.Threading.Tasks;

namespace Shopping.Identidade.API.Models.Interfaces
{
    public interface IIdentityService
    {
        Task<Response> Registro(UsuarioRegistro usuarioRegistro);
        Task<Response> Login(UsuarioLogin usuarioLogin);
    }
}
