using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.BoardGameRequests
{
    public class GetGameBoardByIdRequest : IRequest<Models.Client>
    {
        public GetGameBoardByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}