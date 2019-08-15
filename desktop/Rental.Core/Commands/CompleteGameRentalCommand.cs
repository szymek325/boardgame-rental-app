using System;
using MediatR;

namespace Rental.Core.Commands
{
    internal class CompleteGameRentalCommand : IRequest
    {
        public CompleteGameRentalCommand(Guid gameRentalId, float paidMoney)
        {
            GameRentalId = gameRentalId;
            PaidMoney = paidMoney;
        }

        public Guid GameRentalId { get; }
        public float PaidMoney { get; }
    }
}