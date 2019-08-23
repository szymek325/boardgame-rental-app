using System;
using Rental.CQRS;

namespace Rental.Core.Commands
{
    public class CompleteRentalCommand : ICommand
    {
        public CompleteRentalCommand(Guid gameRentalId, float paidMoney)
        {
            GameRentalId = gameRentalId;
            PaidMoney = paidMoney;
        }

        public Guid GameRentalId { get; }
        public float PaidMoney { get; }
    }
}