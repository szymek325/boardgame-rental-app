using System;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Clients;

namespace Playingo.Application.Clients.Queries
{
    public class GetClientByIdQuery : IQuery<Client>
    {
        public GetClientByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    internal class GetClientByIdQueryHandler : IQueryHandler<GetClientByIdQuery, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(GetClientByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ClientRepository.GetByIdAsync(query.Id, cancellationToken);
            return entity;
        }
    }
}