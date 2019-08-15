﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;

namespace Rental.Core.Requests.BoardGames
{
    internal class RemoveBoardGameRequestHandler : IRequestHandler<RemoveBoardGameRequest, string>
    {
        private readonly IMediatorService _mediatorService;

        public RemoveBoardGameRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task<string> Handle(RemoveBoardGameRequest request, CancellationToken cancellationToken)
        {
            var canBeRemoved =
                await _mediatorService.Request(new CheckIfBoardGameHasOnlyCompletedRentalsQuery(request.Id),
                    cancellationToken);
            if (!canBeRemoved) return $"BoardGame with id {request.Id} can't be removed because of open rentals";

            await _mediatorService.Notify(new RemoveAndSaveBoardGameCommand(request.Id), cancellationToken);
            return $"BoardGame with id {request.Id} was removed successfully";
        }
    }
}