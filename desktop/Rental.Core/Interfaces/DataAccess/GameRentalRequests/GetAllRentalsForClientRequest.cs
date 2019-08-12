using System;
using System.Collections.Generic;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.GameRentalRequests
{
    public class GetAllRentalsForClientRequest : IRequest<IList<GameRental>>
    {
        public GetAllRentalsForClientRequest(Guid clientId)
        {
            ClientId = clientId;
        }
        public Guid ClientId { get; set; }
    }
}