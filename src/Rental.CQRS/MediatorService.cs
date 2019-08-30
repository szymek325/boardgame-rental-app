using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Rental.CQS
{
    public interface IMediatorService
    {
        Task Send(ICommand command, CancellationToken cancellationToken = default);
        Task<T1> Send<T1>(IQuery<T1> query, CancellationToken cancellationToken = default);
    }

    public class MediatorService : IMediatorService
    {
        private readonly IMediator _mediator;

        public MediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Send(ICommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Publish(command, cancellationToken);
        }

        public async Task<T1> Send<T1>(IQuery<T1> query, CancellationToken cancellationToken = default)
        {
            var requestResult = await _mediator.Send(query, cancellationToken);
            return requestResult;
        }
    }
}