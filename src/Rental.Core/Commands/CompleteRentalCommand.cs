using System;
using Rental.CQS;

namespace Rental.Core.Commands
{
    public class CompleteRentalCommand : ICommand
    {
        public CompleteRentalCommand(Guid gameRentalId, decimal paidMoney)
        {
            GameRentalId = gameRentalId;
            PaidMoney = paidMoney;
        }

        public Guid GameRentalId { get; }
        public decimal PaidMoney { get; }
    }
}