using System.Collections.Generic;
using FluentValidation.Results;
using MediatR;

namespace Rental.Core.Requests
{
    internal class GetFormattedValidationMessageRequest : IRequest<string>
    {
        public GetFormattedValidationMessageRequest(IList<ValidationFailure> validationErrors)
        {
            ValidationErrors = validationErrors;
        }

        public IList<ValidationFailure> ValidationErrors { get; set; }
    }
}