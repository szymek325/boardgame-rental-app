using System;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Requests
{
    public class AddBoardGameRequest : IRequest<Guid>
    {
        public AddBoardGameRequest(BoardGame boardGame)
        {
            BoardGame = boardGame;
        }

        public BoardGame BoardGame { get; set; }
    }
}