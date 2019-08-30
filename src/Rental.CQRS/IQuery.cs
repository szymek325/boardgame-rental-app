using MediatR;

namespace Rental.CQS
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}