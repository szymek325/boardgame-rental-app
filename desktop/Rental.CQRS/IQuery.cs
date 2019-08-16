using MediatR;

namespace Rental.CQRS
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}