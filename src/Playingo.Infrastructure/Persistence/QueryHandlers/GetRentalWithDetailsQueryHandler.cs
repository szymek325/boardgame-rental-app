﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Domain.Rentals;
using Playingo.Infrastructure.Persistence.Context;

namespace Playingo.Infrastructure.Persistence.QueryHandlers
{
    //TODO tests for query required
    internal class GetRentalWithDetailsQueryHandler : IQueryHandler<GetRentalWithDetailsQuery, RentalWithDetails>
    {
        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;

        public GetRentalWithDetailsQueryHandler(IMapper mapper, RentalContext rentalContext)
        {
            _mapper = mapper;
            _rentalContext = rentalContext;
        }

        public async Task<RentalWithDetails> Handle(GetRentalWithDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _rentalContext.Rentals
                .Include(x => x.BoardGame)
                .Include(x => x.Client)
                .SingleOrDefaultAsync(x => x.Id == request.GameRentalGuid, cancellationToken);
            var mappedEntity = _mapper.Map<RentalWithDetails>(entity);
            return mappedEntity;
        }
    }
}