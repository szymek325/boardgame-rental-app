using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.CommandHandlers
{
    internal class AddAndSaveBoardGameCommandHandler : INotificationHandler<AddAndSaveBoardGameCommand>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public AddAndSaveBoardGameCommandHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(AddAndSaveBoardGameCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BoardGame>(command.BoardGame);
            await _rentalContext.BoardGames.AddAsync(entity, cancellationToken);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}