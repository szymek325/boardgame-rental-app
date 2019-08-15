using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models;
using Rental.Core.Models.Validation;

namespace Rental.Core.Requests.BoardGames
{
    internal class AddBoardGameRequestHandler : IRequestHandler<AddBoardGameRequest, AddRequestResult>
    {
        private readonly IMediatorService _mediatorService;

        public AddBoardGameRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task<AddRequestResult> Handle(AddBoardGameRequest request,
            CancellationToken cancellationToken)
        {
            var validator = new BoardGameValidator();
            var newBoardGame = new BoardGame(request.Name, request.Price);
            var validationResult = validator.Validate(newBoardGame);
            if (validationResult.IsValid)
            {
                await _mediatorService.Notify(new AddAndSaveBoardGameCommand(newBoardGame), cancellationToken);
                return new AddRequestResult(newBoardGame.Id);
            }

            var validationMessage =
                await _mediatorService.Request(new GetFormattedValidationMessageRequest(validationResult.Errors),
                    cancellationToken);
            return new AddRequestResult(validationMessage);
        }
    }
}