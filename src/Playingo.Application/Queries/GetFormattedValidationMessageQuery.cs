using System.Collections.Generic;
using FluentValidation.Results;
using Rental.CQS;

namespace Playingo.Application.Queries
{
    internal class GetFormattedValidationMessageQuery : IQuery<string>
    {
        public GetFormattedValidationMessageQuery(IList<ValidationFailure> validationErrors)
        {
            ValidationErrors = validationErrors;
        }

        public IList<ValidationFailure> ValidationErrors { get; set; }
    }
}