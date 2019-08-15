using MediatR;

namespace Rental.Common
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}