using FluentValidation.Results;
using Shopping.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        public CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName: string.Empty, errorMessage:mensagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit())
                AdicionarErro("Houve um erro ao persistir os dados");


            return ValidationResult;
        }
    }
}
