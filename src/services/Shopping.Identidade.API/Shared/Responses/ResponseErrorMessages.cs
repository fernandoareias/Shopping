using System.Collections.Generic;

namespace Shopping.Identidade.API.Shared.Responses
{
    public class ResponseErrorMessages : Response
    {
        public ResponseErrorMessages()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }
}
