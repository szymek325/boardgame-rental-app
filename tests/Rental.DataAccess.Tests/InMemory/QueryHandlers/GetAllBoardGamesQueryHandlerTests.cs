using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.CQRS;
using Rental.DataAccess.Context;
using Rental.DataAccess.Mapping;
using Rental.DataAccess.QueryHandlers;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
{
    public class GetAllBoardGamesQueryHandlerTests
    {
        public GetAllBoardGamesQueryHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetAllBoardGamesQueryHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly IQueryHandler<GetAllBoardGamesQuery, IList<BoardGame>> _sut;

        [Fact]
        public async Task Handle_Should_ReturnEmptyListOfBoardGames_When_BoardGamesTableIsEmpty()
        {
            var result = await _sut.Handle(new GetAllBoardGamesQuery(), new CancellationToken());

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnMappedListOfGameBoards_When_SomeExist()
        {
            var entity1 = new Entities.BoardGame
            {
                Id = Guid.NewGuid()
            };
            var entity2 = new Entities.BoardGame
            {
                Id = Guid.NewGuid()
            };
            var entities = new List<Entities.BoardGame> {entity1, entity2};
            await _rentalContext.BoardGames.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var result = await _sut.Handle(new GetAllBoardGamesQuery(), new CancellationToken());

            result.Should().Contain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
        }
    }
}