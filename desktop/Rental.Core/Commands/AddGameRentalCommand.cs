using System;
using MediatR;

namespace Rental.Core.Commands
{
    internal class AddGameRentalCommand : IRequest
    {
        public AddGameRentalCommand(Guid newGameRentalGuid, Guid clientGuid, Guid boardGameGuid, float chargedDeposit)
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