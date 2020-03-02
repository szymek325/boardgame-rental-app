using System.Collections.Generic;
using FluentValidation.Results;
using Playingo.Application.Common.Mediator;

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