using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Rental.Core.Common.Exceptions;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models.BoardGames;
using Rental.Core.Queries;
using Rental.CQS;

namespace Rental.Core.Commands.Handlers
{
    internal class AddBoardGameCommandHandler : ICommandHandler<AddBoardGameCommand>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IValidator<BoardGame> _validator;

        public AddBoardGameCommandHandler(IMediatorService mediatorService, IValidator<BoardGame> validator)
        {
            _mediatorService = mediatorService;
            _validator = validator;
        }

        public async Task Handle(AddBoardGameCommand command,
            CancellationToken cancellationToken)
        {
            var newBoardGame = new BoardGame(command.NewBoardGameGuid, command.Name, command.Price);
            var validationResult = _validator.Validate(newBoardGame);

            if (validationResult.IsValid)
            {
                await _mediatorService.Send(new AddAndSaveBoardGameCommand(newBoardGame), cancellationToken);
            }
            else
            {
                var validationMessage =
                    await _mediatorService.Send(new GetFormattedValidationMessageQuery(validationResult.Errors),
                        cancellationToken);
                throw new CustomValidationException(validationMessage);
            }
        }
    }
}