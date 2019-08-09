using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Interfaces.DataAccess.Repositories;
using Rental.Core.MediatR;
using Rental.Core.Models.Validation;
using Rental.Core.Notifications;

namespace Rental.Core.Requests.Handlers
{
    internal class AddClientRequestHandler : IRequestHandler<AddClientRequest, Guid>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IUnitOfWork _unitOfWork;

        public AddClientRequestHandler(IMediatorService mediatorService, IUnitOfWork unitOfWork)
        {
            _mediatorService = mediatorService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AddClientRequest request, CancellationToken cancellationToken)
        {
            var validator = new ClientValidator();
            var validationResult = validator.Validate(request.Client);
            if (validationResult.IsValid)
            {
                request.Client.Id = Guid.NewGuid();
                await _unitOfWork.ClientsRepository.AddAsync(request.Client);
                await _unitOfWork.SaveChangesAsync();
                await _mediatorService.Notify(new NewClientAddedNotification(request.Client));
                return request.Client.Id;
            }

            var builder = new StringBuilder();
            foreach (var validationFailure in validationResult.Errors)
                builder.AppendLine($"{validationFailure.PropertyName}- {validationFailure.ErrorMessage}");
            Trace.WriteLine(builder.ToString());

            return Guid.Empty;
        }
    }
}