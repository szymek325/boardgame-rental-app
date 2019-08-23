using System;
using System.Threading;
using System.Threading.Tasks;
using Rental.CQRS;

namespace Rental.Core.Commands.Handlers
{
    internal class CompleteRentalCommandHandler : ICommandHandler<CompleteRentalCommand>
    {
        private readonly IMediatorService _mediatorService;

        public CompleteRentalCommandHandler(IMediatorService mediatorService)
        {
            _mediatorService = mediatorService;
        }

        public async Task Handle(CompleteRentalCommand notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}