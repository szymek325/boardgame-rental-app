using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Rentals.Queries;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.Mapping;
using Playingo.Infrastructure.Persistence.QueryHandlers;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
{
    public class GetAllRentalsForClientQueryHandlerTests
    {
        public GetAllRentalsForClientQueryHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetAllRentalsForClientQueryHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly IQueryHandler<GetAllRentalsForClientQuery, IList<Playingo.Domain.Rentals.Rental>> _sut;

        [Fact]
        public async Task Handle_Should_ReturnEmptyListOfGameRentals_When_TableIsEmpty()
        {
            var input = Guid.NewGuid();

            var result = await _sut.Handle(new GetAllRentalsForClientQuery(input), new CancellationToken());

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnMappedListOfGameRentals_When_TheyHaveCorrectBoardGameId()
        {
            var inputBoardGameIdGuid = Guid.NewGuid();
            var entity1 = new Playingo.Infrastructure.Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                BoardGameId = inputBoardGameIdGuid
            };
            var entity2 = new Playingo.Infrastructure.Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                ClientId = inputBoardGameIdGuid
            };
            var entities = new List<Playingo.Infrastructure.Persistence.Entities.Rental> {entity1, entity2};
            await _rentalContext.Rentals.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var result = await _sut.Handle(new GetAllRentalsForClientQuery(inputBoardGameIdGuid),
                new CancellationToken());

            result.Should().BeOfType<List<Playingo.Domain.Rentals.Rental>>();
            result.Should().NotContain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
            result.Count.Should().Be(1);
        }
    }
}