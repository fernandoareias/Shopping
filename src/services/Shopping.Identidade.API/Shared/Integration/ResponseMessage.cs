using FluentValidation.Results;
using Shopping.Identidade.API.Shared.Messages;

namespace Shopping.Identidade.API.Shared.Integration
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
