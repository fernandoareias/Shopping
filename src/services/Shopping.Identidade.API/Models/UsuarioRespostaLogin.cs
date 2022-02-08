using Shopping.Identidade.API.Shared.Responses;

namespace Shopping.Identidade.API.Models
{
    public class UsuarioRespostaLogin : Response
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioToken UsuarioToken { get; set; }
    }
}
