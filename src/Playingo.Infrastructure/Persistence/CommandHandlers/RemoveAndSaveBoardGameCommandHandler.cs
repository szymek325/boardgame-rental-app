﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.Entities;

namespace Playingo.Infrastructure.Persistence.CommandHandlers
{
    internal class RemoveAndSaveBoardGameCommandHandler : ICommandHandler<RemoveAndSaveBoardGameCommand>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public RemoveAndSaveBoardGameCommandHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(RemoveAndSaveBoardGameCommand command, CancellationToken cancellationToken)
        {
            var boardGame = _mapper.Map<BoardGame>(command.BoardGame);
            _rentalContext.BoardGames.Remove(boardGame);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}