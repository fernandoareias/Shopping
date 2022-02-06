using FluentValidation.Results;
using Shopping.Cliente.API.Shared.Messages;

namespace Shopping.Cliente.API.Shared.Integration
{
    public class ResponseMessage : Message
    {
        public ValidationResult ValidationResult { get; set; }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
