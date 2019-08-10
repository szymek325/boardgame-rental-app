using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Models.Validation;

namespace Rental.Core.Requests.Handlers
{
    internal class AddBoardGameRequestHandler : IRequestHandler<AddBoardGameRequest, Guid>
    {
        private readonly IMediatorService _mediatorService;

        public AddBoardGameRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task<Guid> Handle(AddBoardGameRequest request, CancellationToken cancellationToken)
        {
            var validator = new BoardGameValidator();
            var validationResult = validator.Validate(request.BoardGame);
            if (validationResult.IsValid)
            {
                var response = await _mediatorService.Request(new AddAndSaveBoardGameRequest(request.BoardGame), cancellationToken);
                //await _mediatorService.Notify(new NewClientAddedNotification(request.Client));
                return response.Id;
            }

            var builder = new StringBuilder();
            foreach (var validationFailure in validationResult.Errors)
                builder.AppendLine($"{validationFailure.PropertyName}- {validationFailure.ErrorMessage}");
            Trace.WriteLine(builder.ToString());
            return Guid.Empty;
        }
    }
}