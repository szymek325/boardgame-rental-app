using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Common.Interfaces
{
    public interface IRentalRepository
    {
        Task<bool> IsThereInProgressForBoardGameAsync(Guid id);
        Task<bool> IsThereInProgressForClient(Guid id);
        Task<IList<Rental>> GetAllForBoardGame(Guid id);
        Task<IList<Rental>> GetAllForClient(Guid id);
        Task<IList<Rental>> GetAll();
        Task<Rental> GetById(Guid id);
        Task<RentalWithDetails> GetWithDetailsById(Guid id);
        Task AddAsync(Rental rental);
        Task Update(Rental rental);
    }
}