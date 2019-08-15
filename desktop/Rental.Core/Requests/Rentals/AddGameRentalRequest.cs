using System;
using MediatR;

namespace Rental.Core.Requests.Rentals
{
    internal class AddGameRentalRequest : IRequest
    {
        public AddGameRentalRequest(Guid newGameRentalGuid, Guid clientGuid, Guid boardGameGuid, float chargedDeposit)
        {
            NewGameRentalGuid = newGameRentalGuid;
            ClientGuid = clientGuid;
            BoardGameGuid = boardGameGuid;
            ChargedDeposit = chargedDeposit;
        }

        public Guid NewGameRentalGuid { get; set; }
        public Guid ClientGuid { get; }
        public Guid BoardGameGuid { get; }
        public float ChargedDeposit { get; }
    }
}