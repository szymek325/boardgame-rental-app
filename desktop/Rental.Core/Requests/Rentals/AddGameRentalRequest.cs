using System;
using MediatR;

namespace Rental.Core.Requests.Rentals
{
    internal class AddGameRentalRequest : IRequest<AddRequestResult>
    {
        public AddGameRentalRequest(Guid clientGuid, Guid boardGameGuid, float chargedDeposit)
        {
            ClientGuid = clientGuid;
            BoardGameGuid = boardGameGuid;
            ChargedDeposit = chargedDeposit;
        }

        public Guid ClientGuid { get; }
        public Guid BoardGameGuid { get; }
        public float ChargedDeposit { get; }
    }
}