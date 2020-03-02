using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Playingo.Application.Common.Interfaces;
using Playingo.Application.Common.Mediator;
using Playingo.Domain.Clients;

namespace Playingo.Application.Clients.Queries
{
    public class GetAllClientsQuery : IQuery<IList<Client>>
    {
    }

    internal class GetAllClientsQueryHandler : IQueryHandler<GetAllClientsQuery, IList<Client>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Client>> Handle(GetAllClientsQuery query, CancellationToken cancellationToken)
        {
            var clients = await _unitOfWork.ClientRepository.GetAllAsync(cancellationToken);
            return clients;
        }
    }
}