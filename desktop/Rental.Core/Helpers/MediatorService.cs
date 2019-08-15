using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Rental.Core.Helpers
{
    public interface IMediatorService
    {
        Task SendCommand(INotification command, CancellationToken cancellationToken = default);

        Task SendCommand(IRequest command, CancellationToken cancellationToken = default);

        Task<T1> SendQuery<T1>(IRequest<T1> query, CancellationToken cancellationToken = default);
    }

    public class MediatorService : IMediatorService
    {
        private readonly IMediator _mediator;

        public MediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendCommand(INotification command, CancellationToken cancellationToken = default)
        {
            await _mediator.Publish(command, cancellationToken);
        }

        public async Task SendCommand(IRequest command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
        }

        public async Task<T1> SendQuery<T1>(IRequest<T1> query, CancellationToken cancellationToken = default)
        {
            var requestResult = await _mediator.Send(query, cancellationToken);
            return requestResult;
        }
    }
}