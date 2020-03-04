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
    public class UpdateBoardGameCommand : ICommand
    {
        public UpdateBoardGameCommand(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal Price { get; }
    }

    internal class UpdateBoardGameCommandHandler : ICommandHandler<UpdateBoardGameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationMessageBuilder _validationMessageBuilder;
        private readonly IValidator<BoardGame> _validator;

        public UpdateBoardGameCommandHandler(IUnitOfWork unitOfWork, IValidationMessageBuilder validationMessageBuilder,
            IValidator<BoardGame> validator)
        {
            _unitOfWork = unitOfWork;
            _validationMessageBuilder = validationMessageBuilder;
            _validator = validator;
        }

        public async Task Handle(UpdateBoardGameCommand command, CancellationToken cancellationToken)
        {
            var boardGame = await _unitOfWork.BoardGameRepository.GetByIdAsync(command.Id, cancellationToken);
            if (boardGame == null)
                throw new BoardGameNotFoundException(command.Id);

            boardGame.Name = command.Name;
            boardGame.Price = command.Price;
            var validationResult = _validator.Validate(boardGame);

            if (validationResult.IsValid)
            {
                await _unitOfWork.BoardGameRepository.Update(boardGame);
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