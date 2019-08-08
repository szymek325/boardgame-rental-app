using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rental.Core.Interfaces.DataAccess;
using Rental.Core.MediatR;
using Rental.Core.Models.Validation;
using Rental.Core.Notifications;

namespace Rental.Core.Handlers
{
    internal class AddClientRequestHandler : INotificationHandler<AddClientRequest>
    {
        private readonly IMediatorService _mediatorService;
        private readonly IUnitOfWork _unitOfWork;

        public AddClientRequestHandler(IMediatorService mediatorService, IUnitOfWork unitOfWork)
        {
            _mediatorService = mediatorService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AddClientRequest request, CancellationToken cancellationToken)
        {
            var validator = new ClientValidator();
            var result = validator.Validate(request.Client);
            if (result.IsValid)
            {
                await _unitOfWork.ClientsRepository.AddAsync(request.Client);
                await _mediatorService.Notify(new NewClientAddedNotification(request.Client));
            }
            else
            {
                var builder = new StringBuilder();
                foreach (var validationFailure in result.Errors)
                    builder.AppendLine($"{validationFailure.PropertyName}- {validationFailure.ErrorMessage}");
                Trace.WriteLine(builder.ToString());
            }
        }
    }
}