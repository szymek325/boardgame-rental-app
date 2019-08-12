using System;
using MediatR;

namespace Rental.Core.Requests.Rentals
{
    internal class CompleteGameRentalRequest : IRequest
    {
        public CompleteGameRentalRequest(Guid gameRentalId, float paidMoney)
        {
            GameRentalId = gameRentalId;
            PaidMoney = paidMoney;
        }

        public Guid GameRentalId { get; }
        public float PaidMoney { get; }
    }
}