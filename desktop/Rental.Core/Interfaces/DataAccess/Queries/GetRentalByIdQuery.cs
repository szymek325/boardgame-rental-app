using System;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetRentalByIdQuery : IRequest<GameRental>
    {
        public GetRentalByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}