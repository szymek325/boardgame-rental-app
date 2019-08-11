using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Models;
using Rental.Core.Models.Validation;

namespace Rental.Core.Requests.Handlers
{
    internal class AddBoardGameRequestHandler : IRequestHandler<AddBoardGameRequest, AddBoardGameRequestResult>
    {
        private readonly IMediatorService _mediatorService;

        public AddBoardGameRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task<AddBoardGameRequestResult> Handle(AddBoardGameRequest request,
            CancellationToken cancellationToken)
        {
            var validator = new BoardGameValidator();
            var newBoardGame = new BoardGame(request.Name, request.Price);
            var validationResult = validator.Validate(newBoardGame);
            if (validationResult.IsValid)
            {
                newBoardGame.Id = Guid.NewGuid();
                await _mediatorService.Notify(new AddAndSaveBoardGameNotification(newBoardGame), cancellationToken);
                //await _mediatorService.Notify(new NewClientAddedNotification(request.Client));
                return new AddBoardGameRequestResult(newBoardGame.Id);
            }

            var builder = new StringBuilder();
            foreach (var validationFailure in validationResult.Errors)
                builder.AppendLine($"{validationFailure.PropertyName}- {validationFailure.ErrorMessage}");

            return new AddBoardGameRequestResult(builder.ToString());
        }
    }
}