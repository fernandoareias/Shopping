

using FluentValidation.Results;
using System.Collections.Generic;

namespace Shopping.Identidade.API.Shared.Notification
{
    public interface INotification
    {
        IEnumerable<string> Erros
        {
            get;
        }

        void AdicionarErro(string error);
        void AdicionarErro(ValidationResult error);
        void AdicionarErros(List<string> erros);
        bool LimparErros();
    }
}
