using System.Collections.Generic;
using FluentValidation.Results;
using MediatR;

namespace Rental.Core.Queries
{
    internal class GetFormattedValidationMessageQuery : IRequest<string>
    {
        public GetFormattedValidationMessageQuery(IList<ValidationFailure> validationErrors)
        {
            ValidationErrors = validationErrors;
        }

        public IList<ValidationFailure> ValidationErrors { get; set; }
    }
}