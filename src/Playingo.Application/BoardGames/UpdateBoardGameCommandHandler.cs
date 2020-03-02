using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Application.Queries;
using Playingo.Domain.BoardGames;
using Rental.CQS;

namespace Playingo.Application.BoardGames
{
    internal class UpdateBoardGameCommandHandler : ICommandHandler<UpdateBoardGameCommand>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IValidator<BoardGame> _validator;

        public UpdateBoardGameCommandHandler(IMediatorService mediatorService, IValidator<BoardGame> validator)
        {
            _mediatorService = mediatorService;
            _validator = validator;
        }

        public async Task Handle(UpdateBoardGameCommand command, CancellationToken cancellationToken)
        {
            var boardGame = await _mediatorService.Send(new GetBoardGameByIdQuery(command.Id), cancellationToken);
            if (boardGame == null)
                throw new BoardGameNotFoundException(command.Id);

            boardGame.Name = command.Name;
            boardGame.Price = command.Price;
            var validationResult = _validator.Validate(boardGame);

            if (validationResult.IsValid)
            {
                await _mediatorService.Send(new UpdateAndSaveBoardGameCommand(boardGame), cancellationToken);
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