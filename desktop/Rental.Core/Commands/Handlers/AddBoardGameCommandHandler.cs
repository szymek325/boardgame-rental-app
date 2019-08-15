using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Rental.Core.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models;
using Rental.Core.Models.Validation;
using Rental.Core.Queries;

namespace Rental.Core.Commands.Handlers
{
    internal class AddBoardGameCommandHandler : AsyncRequestHandler<AddBoardGameCommand>
    {
        private readonly IMediatorService _mediatorService;

        public AddBoardGameCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(AddBoardGameCommand command,
            CancellationToken cancellationToken)
        {
            var validator = new BoardGameValidator();
            var newBoardGame = new BoardGame(command.NewBoardGameGuid, command.Name, command.Price);
            var validationResult = validator.Validate(newBoardGame);

            if (validationResult.IsValid)
                await _mediatorService.SendCommand(new AddAndSaveBoardGameCommand(newBoardGame), cancellationToken);

            var validationMessage =
                await _mediatorService.SendQuery(new GetFormattedValidationMessageQuery(validationResult.Errors),
                    cancellationToken);
            throw new ValidationException(validationMessage);
        }
    }
}