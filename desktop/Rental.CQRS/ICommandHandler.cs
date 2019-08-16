using MediatR;

namespace Rental.CQRS
{
    public interface ICommandHandler<in TRequest> : INotificationHandler<TRequest>
        where TRequest : ICommand
    {
    }
}