using FluentValidation.Results;
using MediatR;
using Shopping.Cliente.API.Shared.Messages;
using System;

namespace Shopping.Cliente.API.Shared.Commands
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
