using System;
using System.Collections.Generic;
using Rental.CQS;

namespace Rental.Core.Interfaces.DataAccess.Queries
{
    public class GetAllRentalsForBoardGameQuery : IQuery<IList<Playingo.Domain.Rentals.Rental>>
    {
        public GetAllRentalsForBoardGameQuery(Guid boardGameId)
        {
            BoardGameId = boardGameId;
        }

        public Guid BoardGameId { get; set; }
    }
}