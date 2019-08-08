using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Rental.Core.Requests.Handlers
{
    internal class RemoveClientRequestHandler : IRequestHandler<RemoveClientRequest, string>
    {
        private readonly IMediator _mediator;

        public RemoveClientRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Handle(RemoveClientRequest request, CancellationToken cancellationToken)
        {
            var client = await _mediator.Send(new GetClientByIdRequest(request.Id), cancellationToken);
            //var anyOpen
            //TODO
            return String.Empty;;
        }
    }
}