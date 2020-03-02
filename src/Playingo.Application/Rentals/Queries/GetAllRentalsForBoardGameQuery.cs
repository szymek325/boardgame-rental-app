using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
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

    internal class
        GetAllRentalsForBoardGameQueryHandler : IQueryHandler<GetAllRentalsForBoardGameQuery,
            IList<Rental>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRentalsForBoardGameQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Rental>> Handle(GetAllRentalsForBoardGameQuery query,
            CancellationToken cancellationToken)
        {
            var entities =
                await _unitOfWork.RentalRepository.GetAllForBoardGameAsync(query.BoardGameId, cancellationToken);
            return entities;
        }
    }
}