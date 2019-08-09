using System.Threading.Tasks;
using MediatR;

namespace Rental.Core.Helpers
{
    public interface IMediatorService
    {
        Task Notify<T>(T notification) where T : INotification;
        Task<T1> Request<T1>(IRequest<T1> request);
    }

    public class MediatorService : IMediatorService
    {
        private readonly IMediator _mediator;

        public MediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Notify<T>(T notification) where T : INotification
        {
            await _mediator.Publish(notification);
        }

        public async Task<T1> Request<T1>(IRequest<T1> request)
        {
            var requestResult = await _mediator.Send(request);
            return requestResult;
        }
    }
}