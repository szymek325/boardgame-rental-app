using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models;
using Rental.Core.Models.Validation;

namespace Rental.Core.Requests.BoardGames
{
    internal class AddBoardGameRequestHandler : AsyncRequestHandler<AddBoardGameRequest>
    {
        private readonly IMediatorService _mediatorService;

        public AddBoardGameRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(AddBoardGameRequest request,
            CancellationToken cancellationToken)
        {
            var validator = new BoardGameValidator();
            var newBoardGame = new BoardGame(request.NewBoardGameGuid, request.Name, request.Price);
            var validationResult = validator.Validate(newBoardGame);

            if (validationResult.IsValid)
                await _mediatorService.SendCommand(new AddAndSaveBoardGameCommand(newBoardGame), cancellationToken);

            var validationMessage =
                await _mediatorService.SendQuery(new GetFormattedValidationMessageRequest(validationResult.Errors),
                    cancellationToken);
            throw new ValidationException(validationMessage);
        }
    }
}