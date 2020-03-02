using System;
using Rental.CQS;

namespace Playingo.Application.Rentals
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