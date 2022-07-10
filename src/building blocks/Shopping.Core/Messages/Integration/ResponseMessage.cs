using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.Messages.Integration
{
    public class ResponseMessage : Message
    {
        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public ValidationResult ValidationResult { get; set; }
    }
}
