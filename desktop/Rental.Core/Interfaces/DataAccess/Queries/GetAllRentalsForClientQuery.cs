using System;
using System.Collections.Generic;
using MediatR;
using Rental.Common;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetAllRentalsForClientQuery : IQuery<IList<GameRental>>
    {
        public GetAllRentalsForClientQuery(Guid clientId)
        {
            ClientId = clientId;
        }

        public Guid ClientId { get; set; }
    }
}