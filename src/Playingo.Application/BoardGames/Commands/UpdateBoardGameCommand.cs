﻿using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Playingo.Application.BoardGames.Queries;
using Playingo.Application.Common.Exceptions;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Application.Validation;
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