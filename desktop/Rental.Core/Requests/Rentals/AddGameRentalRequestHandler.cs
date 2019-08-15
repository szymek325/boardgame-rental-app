using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using Rental.Core.Helpers;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.Core.Models.Validation;

namespace Rental.Core.Requests.Rentals
{
    internal class AddGameRentalRequestHandler : AsyncRequestHandler<AddGameRentalRequest>
    {
        private readonly IMediatorService _mediatorService;

        public AddGameRentalRequestHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        protected override async Task Handle(AddGameRentalRequest request, CancellationToken cancellationToken)
        {
            var validator = new RentalValidation();
            var newGameRental = new GameRental(request.NewGameRentalGuid, request.ClientGuid, request.BoardGameGuid,
                request.ChargedDeposit);
            var validationResult = validator.Validate(newGameRental);
            if (validationResult.IsValid)
            {
                var gameCanBeRented =
                    await _mediatorService.SendQuery(
                        new CheckIfBoardGameHasOnlyCompletedRentalsQuery(request.BoardGameGuid),
                        cancellationToken);
                if (gameCanBeRented)
                    await _mediatorService.SendCommand(new AddAndSaveRentalCommand(newGameRental), cancellationToken);
                else
                    validationResult.Errors.Add(new ValidationFailure(nameof(newGameRental.BoardGameId),
                        $"BoardGame {request.BoardGameGuid} is not available for rental - already rented"));
            }

            var validationMessage =
                await _mediatorService.SendQuery(new GetFormattedValidationMessageRequest(validationResult.Errors),
                    cancellationToken);
            throw new ValidationException(validationMessage);
        }
    }
}