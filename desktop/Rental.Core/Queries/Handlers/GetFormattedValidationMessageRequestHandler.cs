using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Rental.Core.Queries.Handlers
{
    internal class
        GetFormattedValidationMessageRequestHandler : IRequestHandler<GetFormattedValidationMessageRequest, string>
    {
        public Task<string> Handle(GetFormattedValidationMessageRequest request, CancellationToken cancellationToken)
        {
            var builder = new StringBuilder();
            foreach (var validationFailure in request.ValidationErrors)
                builder.AppendLine($"{validationFailure.PropertyName}- {validationFailure.ErrorMessage}");
            return Task.FromResult(builder.ToString());
        }
    }
}