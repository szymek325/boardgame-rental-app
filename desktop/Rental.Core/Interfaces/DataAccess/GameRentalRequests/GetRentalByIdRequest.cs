using System;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.GameRentalRequests
{
    public class GetRentalByIdRequest : IRequest<GameRental>
    {
        public GetRentalByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}