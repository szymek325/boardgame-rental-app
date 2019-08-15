using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;

namespace Rental.DataAccess.CommandHandlers
{
    internal class UpdateAndSaveBoardGameCommandHandler : INotificationHandler<UpdateAndSaveBoardGameCommand>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public UpdateAndSaveBoardGameCommandHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task Handle(UpdateAndSaveBoardGameCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BoardGame>(command.BoardGame);
            _rentalContext.BoardGames.Update(entity);
            await _rentalContext.SaveChangesAsync(cancellationToken);
        }
    }
}