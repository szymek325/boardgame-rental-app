using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;
using Rental.DataAccess.Handlers.BoardGameHandlers;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.BoardGameHandlers
{
    public class GetAllBoardGamesRequestHandlerTests
    {
        public GetAllBoardGamesRequestHandlerTests()
        {
            _rentalContext = new RentalContext(new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            _mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetAllBoardGamesRequestHandler(_mapper, _rentalContext);
        }

        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;
        private readonly IRequestHandler<GetAllBoardGamesRequest, IList<BoardGame>> _sut;

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

            var result = await _sut.Handle(new GetAllBoardGamesRequest(), new CancellationToken());

            result.Should().Contain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
        }
    }
}