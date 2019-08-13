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
    public class GetBoardGameByIdRequestHandlerTests
    {
        public GetBoardGameByIdRequestHandlerTests()
        {
            _rentalContext = new RentalContext(new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetBoardGameByIdRequestHandler(mapper, _rentalContext);
        }

        private readonly RentalContext _rentalContext;
        private readonly IRequestHandler<GetBoardGameByIdRequest, BoardGame> _sut;

        [Fact]
        public async Task Handle_Should_ReturnElementWithSpecificId()
        {
            var inputId = Guid.NewGuid();
            var entity1 = new Entities.BoardGame
            {
                Id = inputId,
                Name = "test1"
            };
            var entity2 = new Entities.BoardGame
            {
                Id = Guid.NewGuid(),
                Name = "test2"
            };
            var entities = new List<Entities.BoardGame> {entity1, entity2};
            await _rentalContext.BoardGames.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var result = await _sut.Handle(new GetBoardGameByIdRequest(inputId), new CancellationToken());

            result.Id.Should().Be(inputId);
            result.Name.Should().Be(entity1.Name);
            result.Should().BeOfType<BoardGame>();
        }

        [Fact]
        public async Task Handle_Should_ReturnNull_When_NoMatchingElementsFound()
        {
            var entity1 = new Entities.BoardGame
            {
                Id = Guid.NewGuid(),
                Name = "test1",
                Price = 0,
                CreationTime = DateTime.Now
            };
            var entity2 = new Entities.BoardGame
            {
                Id = Guid.NewGuid(),
                Name = "test2",
                Price = 0,
                CreationTime = DateTime.Now
            };
            var entities = new List<Entities.BoardGame> {entity1, entity2};
            await _rentalContext.BoardGames.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(new GetBoardGameByIdRequest(Guid.NewGuid()), new CancellationToken());

            response.Should().BeNull();
        }
    }
}