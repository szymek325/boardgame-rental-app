using System;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class GetBoardGameByIdRequest : IRequest<BoardGame>
    {
        public GetBoardGameByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}