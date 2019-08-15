using System;
using MediatR;

namespace Rental.Core.Requests.Rentals
{
    internal class AddGameRentalRequest : IRequest<AddRequestResult>
    {
        public AddGameRentalRequest(Guid gameRentalGuid, Guid clientGuid, Guid boardGameGuid, float chargedDeposit)
        {
            GameRentalGuid = gameRentalGuid;
            ClientGuid = clientGuid;
            BoardGameGuid = boardGameGuid;
            ChargedDeposit = chargedDeposit;
        }

        public Guid GameRentalGuid { get; set; }
        public Guid ClientGuid { get; }
        public Guid BoardGameGuid { get; }
        public float ChargedDeposit { get; }
    }
}