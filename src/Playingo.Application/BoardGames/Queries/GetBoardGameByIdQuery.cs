using System;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.BoardGames;

namespace Playingo.Application.BoardGames.Queries
{
    public class GetBoardGameByIdQuery : IQuery<BoardGame>
    {
        public GetBoardGameByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    internal class GetBoardGameByIdQueryHandler : IQueryHandler<GetBoardGameByIdQuery, BoardGame>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBoardGameByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BoardGame> Handle(GetBoardGameByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.BoardGameRepository.GetByIdAsync(query.Id, cancellationToken);
            return entity;
        }
    }
}