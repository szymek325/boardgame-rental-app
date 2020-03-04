using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain.BoardGames;
using Playingo.Infrastructure.Persistence.Context;
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
            _testContext = new PlayingoContext(contextOptions);
            _sut = new UnitOfWork(new PlayingoContext(contextOptions), mapper);
        }

        private readonly PlayingoContext _testContext;
        private readonly IUnitOfWork _sut;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        [Fact]
        public async Task AddAsync_Should_AddBoardGameToDb_When_MethodCalled()
        {
            var boardGame = new BoardGame(Guid.NewGuid(), "test", 15);
            var entity = new Persistence.Entities.BoardGame
            {
                Id = boardGame.Id,
                Name = boardGame.Name,
                Price = boardGame.Price,
                CreationTime = boardGame.CreationTime
            };
            await _sut.BoardGameRepository.AddAsync(boardGame, _cancellationToken);

            await _sut.SaveChangesAsync(_cancellationToken);

            _testContext.BoardGames.SingleOrDefault(x => x.Id == boardGame.Id).Should().BeEquivalentTo(entity);
        }

        [Fact]
        public void AddAsync_Should_ThrowArgumentException_When_ElementWithThisIdExist()
        {
            var boardGame = new BoardGame(Guid.NewGuid(), "test", 15);
            var existingEntity = new Persistence.Entities.BoardGame
            {
                Id = boardGame.Id
            };
            _testContext.BoardGames.Add(existingEntity);
            _testContext.SaveChanges();

            Func<Task> act = async () =>
            {
                await _sut.BoardGameRepository.AddAsync(boardGame, _cancellationToken);
                await _sut.SaveChangesAsync(_cancellationToken);
            };

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task GetAllAsync_Should_ReturnEmptyListOfBoardGames_When_BoardGamesTableIsEmpty()
        {
            var result = await _sut.BoardGameRepository.GetAllAsync(_cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_Should_ReturnMappedListOfGameBoards_When_SomeExist()
        {
            var entity1 = new Persistence.Entities.BoardGame
            {
                Id = Guid.NewGuid()
            };
            var entity2 = new Persistence.Entities.BoardGame
            {
                Id = Guid.NewGuid()
            };
            var entities = new List<Persistence.Entities.BoardGame> {entity1, entity2};
            await _testContext.BoardGames.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.BoardGameRepository.GetAllAsync(_cancellationToken);

            result.Should().Contain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnElementWithSpecificId()
        {
            var inputId = Guid.NewGuid();
            var entity1 = new Persistence.Entities.BoardGame
            {
                Id = inputId,
                Name = "test1"
            };
            var entity2 = new Persistence.Entities.BoardGame
            {
                Id = Guid.NewGuid(),
                Name = "test2"
            };
            var entities = new List<Persistence.Entities.BoardGame> {entity1, entity2};
            await _testContext.BoardGames.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.BoardGameRepository.GetByIdAsync(inputId, _cancellationToken);

            result.Id.Should().Be(inputId);
            result.Name.Should().Be(entity1.Name);
            result.Should().BeOfType<BoardGame>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnNull_When_NoMatchingElementsFound()
        {
            var entity1 = new Persistence.Entities.BoardGame
            {
                Id = Guid.NewGuid(),
                Name = "test1",
                Price = 0,
                CreationTime = DateTime.Now
            };
            var entity2 = new Persistence.Entities.BoardGame
            {
                Id = Guid.NewGuid(),
                Name = "test2",
                Price = 0,
                CreationTime = DateTime.Now
            };
            var entities = new List<Persistence.Entities.BoardGame> {entity1, entity2};
            await _testContext.BoardGames.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.BoardGameRepository.GetByIdAsync(Guid.NewGuid(), _cancellationToken);

            result.Should().BeNull();
        }

        [Fact]
        public async Task RemoveById_Should_RemoveClientFromDb_When_ClientExists()
        {
            var inputId = Guid.NewGuid();
            var entities = new List<Persistence.Entities.BoardGame>
            {
                new Persistence.Entities.BoardGame
                {
                    Id = inputId,
                    Name = "test1"
                },
                new Persistence.Entities.BoardGame
                {
                    Id = Guid.NewGuid(),
                    Name = "test2"
                }
            };
            await _testContext.BoardGames.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            await _sut.BoardGameRepository.RemoveByIdAsync(inputId, _cancellationToken);
            await _sut.SaveChangesAsync(_cancellationToken);

            _testContext.BoardGames.FirstOrDefault(x => x.Id == inputId).Should().BeNull();
        }

        [Fact]
        public void RemoveById_Should_ThrowArgumentNullException_When_BoardGameWithProvidedIdDoesNotExist()
        {
            var input = Guid.NewGuid();

            Func<Task> act = async () =>
            {
                await _sut.BoardGameRepository.RemoveByIdAsync(input, _cancellationToken);
                await _sut.SaveChangesAsync(_cancellationToken);
            };

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Update_Should_Throw_When_EntityDoesNotExist()
        {
            var input = new BoardGame(Guid.NewGuid(), "Test Updated", 20);

            Func<Task> act = async () =>
            {
                await _sut.BoardGameRepository.Update(input);
                await _sut.SaveChangesAsync(_cancellationToken);
            };

            act.Should().Throw<DbUpdateConcurrencyException>();
        }

        [Fact]
        public async Task Update_Should_UpdateEntity_When_ItExists()
        {
            var input = new BoardGame(Guid.NewGuid(), "Test Updated", 20);
            var entities = new List<Persistence.Entities.BoardGame>
            {
                new Persistence.Entities.BoardGame
                {
                    Id = input.Id,
                    Name = "test1"
                },
                new Persistence.Entities.BoardGame
                {
                    Id = Guid.NewGuid(),
                    Name = "test2"
                }
            };
            await _testContext.BoardGames.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            await _sut.BoardGameRepository.Update(input);
            await _sut.SaveChangesAsync(_cancellationToken);

            _testContext.BoardGames.Count().Should().Be(entities.Count);
            var result = _testContext.BoardGames.FirstOrDefault(x => x.Id == input.Id);
            result.Name.Should().Be(input.Name);
            result.Price.Should().Be(input.Price);
        }
    }
}