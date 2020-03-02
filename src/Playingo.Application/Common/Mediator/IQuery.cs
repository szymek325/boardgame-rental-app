using MediatR;

namespace Playingo.Application.Common.Mediator
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}