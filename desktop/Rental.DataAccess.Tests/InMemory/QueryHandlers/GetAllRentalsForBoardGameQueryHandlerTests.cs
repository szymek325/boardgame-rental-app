using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.DataAccess.Context;
using Rental.DataAccess.Mapping;
using Rental.DataAccess.QueryHandlers;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
{
    public class GetAllRentalsForBoardGameQueryHandlerTests
    {
        public GetAllRentalsForBoardGameQueryHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetAllRentalsForBoardGameQueryHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly IRequestHandler<GetAllRentalsForBoardGameQuery, IList<GameRental>> _sut;

        [Fact]
        public async Task Handle_Should_ReturnEmptyListOfGameRentals_When_TableIsEmpty()
        {
            var input = Guid.NewGuid();

            var result = await _sut.Handle(new GetAllRentalsForBoardGameQuery(input), new CancellationToken());

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnMappedListOfGameRentals_When_TheyHaveCorrectBoardGameId()
        {
            var inputBoardGameIdGuid = Guid.NewGuid();
            var entity1 = new Entities.GameRental
            {
                Id = Guid.NewGuid(),
                BoardGameId = inputBoardGameIdGuid
            };
            var entity2 = new Entities.GameRental
            {
                Id = Guid.NewGuid(),
                ClientId = inputBoardGameIdGuid
            };
            var entities = new List<Entities.GameRental> {entity1, entity2};
            await _rentalContext.GameRentals.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var result = await _sut.Handle(new GetAllRentalsForBoardGameQuery(inputBoardGameIdGuid),
                new CancellationToken());

            result.Should().BeOfType<List<GameRental>>();
            result.Should().Contain(x => x.Id == entity1.Id);
            result.Should().NotContain(x => x.Id == entity2.Id);
            result.Count.Should().Be(1);
        }
    }
}