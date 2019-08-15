using MediatR;

namespace Rental.Common
{
    public interface ICommand : INotification
    {
    }

    public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
    }

    public interface IQuery<out T> : IRequest<T>
    {
    }

    public interface ICommandHandler<in TRequest> : INotificationHandler<TRequest>
        where TRequest : ICommand
    {
    }
}