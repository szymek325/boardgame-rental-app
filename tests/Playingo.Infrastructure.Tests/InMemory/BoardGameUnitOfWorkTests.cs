using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Interfaces;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.Entities;
using Playingo.Infrastructure.Persistence.Mapping;
using Playingo.Infrastructure.Persistence.Repositories;
using Xunit;

namespace Playingo.Infrastructure.Tests.InMemory
{
    public class UnitOfWorkBoardGameTests
    {
        public UnitOfWorkBoardGameTests()
        {
            var contextOptions = new DbContextOptionsBuilder<PlayingoContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _playingoContext = new PlayingoContext(contextOptions);
            _sut = new UnitOfWork(_playingoContext, mapper);
        }

        private readonly PlayingoContext _playingoContext;
        private readonly IUnitOfWork _sut;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        [Fact]
        public async Task GetAllAsync_Should_ReturnEmptyListOfBoardGames_When_BoardGamesTableIsEmpty()
        {
            var result = await _sut.BoardGameRepository.GetAllAsync(_cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_Should_ReturnMappedListOfGameBoards_When_SomeExist()
        {
            var entity1 = new BoardGame
            {
                Id = Guid.NewGuid()
            };
            var entity2 = new BoardGame
            {
                Id = Guid.NewGuid()
            };
            var entities = new List<BoardGame> {entity1, entity2};
            await _playingoContext.BoardGames.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.BoardGameRepository.GetAllAsync(_cancellationToken);

            result.Should().Contain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnElementWithSpecificId()
        {
            var inputId = Guid.NewGuid();
            var entity1 = new BoardGame
            {
                Id = inputId,
                Name = "test1"
            };
            var entity2 = new BoardGame
            {
                Id = Guid.NewGuid(),
                Name = "test2"
            };
            var entities = new List<BoardGame> {entity1, entity2};
            await _playingoContext.BoardGames.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.BoardGameRepository.GetByIdAsync(inputId, _cancellationToken);

            result.Id.Should().Be(inputId);
            result.Name.Should().Be(entity1.Name);
            result.Should().BeOfType<Domain.BoardGames.BoardGame>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnNull_When_NoMatchingElementsFound()
        {
            var entity1 = new BoardGame
            {
                Id = Guid.NewGuid(),
                Name = "test1",
                Price = 0,
                CreationTime = DateTime.Now
            };
            var entity2 = new BoardGame
            {
                Id = Guid.NewGuid(),
                Name = "test2",
                Price = 0,
                CreationTime = DateTime.Now
            };
            var entities = new List<BoardGame> {entity1, entity2};
            await _playingoContext.BoardGames.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.BoardGameRepository.GetByIdAsync(Guid.NewGuid(), _cancellationToken);

            result.Should().BeNull();
        }
    }
}