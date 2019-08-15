using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Rental.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models.Validation;
using Rental.Core.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class UpdateBoardGameCommandHandler : ICommandHandler<UpdateBoardGameCommand>
    {
        private readonly IMediatorService _mediatorService;

        public UpdateBoardGameCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task Handle(UpdateBoardGameCommand command, CancellationToken cancellationToken)
        {
            var boardGame = await _mediatorService.Send(new GetBoardGameByIdQuery(command.Id), cancellationToken);
            boardGame.Name = command.Name;
            boardGame.Price = command.Price;
            var validator = new BoardGameValidator();
            var validationResult = validator.Validate(boardGame);

            if (validationResult.IsValid)
            {
                await _mediatorService.Send(new UpdateAndSaveBoardGameCommand(boardGame), cancellationToken);
            }
            else
            {
                var validationMessage =
                    await _mediatorService.Send(new GetFormattedValidationMessageQuery(validationResult.Errors),
                        cancellationToken);
                throw new ValidationException(validationMessage);
            }
        }
    }
}