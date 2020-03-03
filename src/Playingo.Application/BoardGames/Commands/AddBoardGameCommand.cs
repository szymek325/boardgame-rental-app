using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Validation;
using Playingo.Domain.BoardGames;

namespace Playingo.Application.BoardGames.Commands
{
    public class AddBoardGameCommand : ICommand
    {
        public AddBoardGameCommand(Guid newBoardGameGuid, string name, decimal price)
        {
            NewBoardGameGuid = newBoardGameGuid;
            Name = name;
            Price = price;
        }

        public Guid NewBoardGameGuid { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    internal class AddBoardGameCommandHandler : ICommandHandler<AddBoardGameCommand>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<BoardGame> _validator;

        public AddBoardGameCommandHandler(IMediatorService mediatorService, IUnitOfWork unitOfWork,
            IValidator<BoardGame> validator)
        {
            _mediatorService = mediatorService;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task Handle(AddBoardGameCommand command,
            CancellationToken cancellationToken)
        {
            var newBoardGame = new BoardGame(command.NewBoardGameGuid, command.Name, command.Price);
            var validationResult = _validator.Validate(newBoardGame);

            if (validationResult.IsValid)
            {
                await _unitOfWork.BoardGameRepository.AddAsync(newBoardGame, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
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