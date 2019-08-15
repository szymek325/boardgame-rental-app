using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models.Validation;
using Rental.Core.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class UpdateBoardGameRequestHandler : AsyncRequestHandler<UpdateBoardGameRequest>
    {
        private readonly IMediatorService _mediatorService;

        public UpdateBoardGameRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(UpdateBoardGameRequest request, CancellationToken cancellationToken)
        {
            var boardGame = await _mediatorService.SendQuery(new GetBoardGameByIdQuery(request.Id), cancellationToken);
            boardGame.Name = request.Name;
            boardGame.Price = request.Price;
            var validator = new BoardGameValidator();
            var validationResult = validator.Validate(boardGame);

            if (validationResult.IsValid)
                await _mediatorService.SendCommand(new UpdateAndSaveBoardGameCommand(boardGame), cancellationToken);

            var validationMessage =
                await _mediatorService.SendQuery(new GetFormattedValidationMessageRequest(validationResult.Errors),
                    cancellationToken);
            throw new ValidationException(validationMessage);
        }
    }
}