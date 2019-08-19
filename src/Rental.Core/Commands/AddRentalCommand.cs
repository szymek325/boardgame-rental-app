using System;
using Rental.CQRS;

namespace Rental.Core.Commands
{
    public class AddRentalCommand : ICommand
    {
        public AddRentalCommand(Guid newGameRentalGuid, Guid clientGuid, Guid boardGameGuid, float chargedDeposit)
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