﻿using System.Collections.Generic;
using FluentValidation.Results;
using Rental.CQRS;

namespace Rental.Core.Queries
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