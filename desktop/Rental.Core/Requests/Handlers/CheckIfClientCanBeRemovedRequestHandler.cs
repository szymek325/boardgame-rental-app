using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Interfaces.DataAccess;

namespace Rental.Core.Requests.Handlers
{
    internal class CheckIfClientCanBeRemovedRequestHandler : IRequestHandler<CheckIfClientCanBeRemovedRequest, bool>
    {
        private IUnitOfWork _unitOfWork;

        public CheckIfClientCanBeRemovedRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckIfClientCanBeRemovedRequest request, CancellationToken cancellationToken)
        {
            //var hasAnyOpen = _unitOfWork.GameRentalsRepository.Where(x => x.Id = Guid.NewGuid());
            //TODO
            return true;
        }
    }
}