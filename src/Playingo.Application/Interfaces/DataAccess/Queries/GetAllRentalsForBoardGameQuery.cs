﻿using System;
using System.Collections.Generic;
using Playingo.Application.Common.Mediator;

namespace Playingo.Application.Interfaces.DataAccess.Queries
{
    public class GetAllRentalsForBoardGameQuery : IQuery<IList<Domain.Rentals.Rental>>
    {
        public GetAllRentalsForBoardGameQuery(Guid boardGameId)
        {
            BoardGameId = boardGameId;
        }

        public Guid BoardGameId { get; set; }
    }
}