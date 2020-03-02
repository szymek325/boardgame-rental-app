using MediatR;

namespace Playingo.Application.Common.Mediator
{
    public interface ICommandHandler<in TRequest> : INotificationHandler<TRequest>
        where TRequest : ICommand
    {
    }
}