using System;
using System.Collections.Generic;
using Rental.CQRS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetAllRentalsForBoardGameQuery : IQuery<IList<Models.Rentals.Rental>>
    {
        public GetAllRentalsForBoardGameQuery(Guid boardGameId)
        {
            BoardGameId = boardGameId;
        }

        public Guid BoardGameId { get; set; }
    }
}