using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Identidade.API.Shared.Notification
{
    public class Notification : INotification
    {
        internal List<string> _errors { get; private set; }

        IEnumerable<string> INotification.Erros { get => _errors; }

        public void AdicionarErro(string error)
        {
            _errors.Add(error);
        }

        public void AdicionarErros(List<string> erros)
        {
            erros.ForEach(e => _errors.Add(e));
        }

        public bool LimparErros()
        {
            _errors = new List<string>();
            return !_errors.Any();
        }

        public void AdicionarErro(ValidationResult error)
        {
            error.Errors.ForEach(e => _errors.Add(e.ErrorMessage));
        }

        
    }
}
