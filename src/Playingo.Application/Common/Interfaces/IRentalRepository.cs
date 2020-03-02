using System.Threading.Tasks;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Common.Interfaces
{
    public interface IRentalRepository
    {
        Task AddAsync(Rental rental);
    }
}