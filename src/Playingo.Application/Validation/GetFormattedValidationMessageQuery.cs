using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.Validation
{
    internal class GetFormattedValidationMessageQuery : IQuery<string>
    {
        public GetFormattedValidationMessageQuery(IList<ValidationFailure> validationErrors)
        {
            ValidationErrors = validationErrors;
        }

        public IList<ValidationFailure> ValidationErrors { get; set; }
    }

    internal class GetFormattedValidationMessageQueryHandler : IQueryHandler<GetFormattedValidationMessageQuery, string>
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