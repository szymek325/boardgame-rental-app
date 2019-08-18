﻿using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rental.CQRS;

namespace Rental.Core.Queries.Handlers
{
    internal class
        GetFormattedValidationMessageQueryHandler : IQueryHandler<GetFormattedValidationMessageQuery, string>
    {
        public Task<string> Handle(GetFormattedValidationMessageQuery query, CancellationToken cancellationToken)
        {
            var builder = new StringBuilder();
            foreach (var validationFailure in query.ValidationErrors)
                builder.AppendLine($"{validationFailure.PropertyName}- {validationFailure.ErrorMessage}");
            return Task.FromResult(builder.ToString());
        }
    }
}