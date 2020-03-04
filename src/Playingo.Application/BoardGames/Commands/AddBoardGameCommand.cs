using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Common.Validation;
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

        public Guid NewBoardGameGuid { get; }
        public string Name { get; }
        public decimal Price { get; }
    }

    internal class AddBoardGameCommandHandler : ICommandHandler<AddBoardGameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationMessageBuilder _validationMessageBuilder;
        private readonly IValidator<BoardGame> _validator;

        public AddBoardGameCommandHandler(IUnitOfWork unitOfWork, IValidationMessageBuilder validationMessageBuilder,
            IValidator<BoardGame> validator)
        {
            _unitOfWork = unitOfWork;
            _validationMessageBuilder = validationMessageBuilder;
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
                var validationMessage = _validationMessageBuilder.CreateMessage(validationResult.Errors);
                throw new CustomValidationException(validationMessage);
            }
        }
    }
}