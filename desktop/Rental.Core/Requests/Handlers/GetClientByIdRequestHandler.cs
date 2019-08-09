using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Interfaces.DataAccess.Repositories;
using Rental.Core.Models;

namespace Rental.Core.Requests.Handlers
{
    internal class GetClientByIdRequestHandler : IRequestHandler<GetClientByIdRequest, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientByIdRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ClientsRepository.GetAsync(request.Id);
        }
    }
}