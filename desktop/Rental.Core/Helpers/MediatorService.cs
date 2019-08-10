using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Rental.Core.Helpers
{
    public interface IMediatorService
    {
        Task Notify<T>(T notification, CancellationToken cancellationToken = default) where T : INotification;
        Task<T1> Request<T1>(IRequest<T1> request, CancellationToken cancellationToken = default);
    }

    public class MediatorService : IMediatorService
    {
        private readonly IMediator _mediator;

        public MediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Notify<T>(T notification, CancellationToken cancellationToken = default)
            where T : INotification
        {
            await _mediator.Publish(notification, cancellationToken);
        }

        public async Task<T1> Request<T1>(IRequest<T1> request, CancellationToken cancellationToken = default)
        {
            var requestResult = await _mediator.Send(request, cancellationToken);
            return requestResult;
        }
    }
}