using System;
using System.Collections.Generic;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.GameRentalRequests
{
    public class GetAllRentalsForBoardGameRequest : IRequest<IList<GameRental>>
    {
        public GetAllRentalsForBoardGameRequest(Guid boardGameId)
        {
            BoardGameId = boardGameId;
        }

        public Guid BoardGameId { get; set; }
    }
}