using System;
using System.Collections.Generic;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals.Queries
{
    public class GetAllRentalsForBoardGameQuery : IQuery<IList<Rental>>
    {
        public GetAllRentalsForBoardGameQuery(Guid boardGameId)
        {
            BoardGameId = boardGameId;
        }

        public Guid BoardGameId { get; set; }
    }
}