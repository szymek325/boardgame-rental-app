using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Playingo.Domain.Rentals
{
    public interface IRentalRepository
    {
        Task<bool> AreAllCompletedForBoardGameAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> AreAllCompletedForClientAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IList<Rental>> GetAllForBoardGameAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IList<Rental>> GetAllForClientAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IList<Rental>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Rental> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<RentalWithDetails> GetWithDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Rental rental, CancellationToken cancellationToken = default);
        Task Update(Rental rental);
    }
}