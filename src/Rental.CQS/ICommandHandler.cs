using MediatR;

namespace Rental.CQS
{
    public interface ICommandHandler<in TRequest> : INotificationHandler<TRequest>
        where TRequest : ICommand
    {
    }
}