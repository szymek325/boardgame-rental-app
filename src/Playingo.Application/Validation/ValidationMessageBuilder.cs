using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;

namespace Playingo.Application.Validation
{
    internal interface IValidationMessageBuilder
    {
        string CreateMessage(IList<ValidationFailure> validationErrors);
    }

    public class ValidationMessageBuilder : IValidationMessageBuilder
    {
        public string CreateMessage(IList<ValidationFailure> validationErrors)
        {
            var builder = new StringBuilder();
            foreach (var validationFailure in validationErrors)
                builder.AppendLine($"{validationFailure.PropertyName}- {validationFailure.ErrorMessage}");
            return builder.ToString();
        }
    }
}