using System.Collections.Generic;

namespace Shopping.Cliente.API.Shared.Responses
{
    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }
}
