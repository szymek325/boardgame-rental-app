using MediatR;

namespace Rental.Common
{
    public interface ICommandHandler<in TRequest> : INotificationHandler<TRequest>
        where TRequest : ICommand
    {
    }
}