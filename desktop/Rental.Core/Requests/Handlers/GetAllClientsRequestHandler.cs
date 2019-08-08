using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Interfaces.DataAccess;
using Rental.Core.Models;

namespace Rental.Core.Requests.Handlers
{
    internal class GetAllClientsRequestHandler : IRequestHandler<GetAllClientsRequest, IList<Client>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllClientsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IList<Client>> Handle(GetAllClientsRequest request, CancellationToken cancellationToken)
        {
            return _unitOfWork.ClientsRepository.GetAll().ToList();
        }
    }
}