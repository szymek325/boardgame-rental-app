using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain;
using Playingo.Domain.Rentals;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.Mapping;
using Playingo.Infrastructure.Persistence.Repositories;
using Xunit;

namespace Playingo.Infrastructure.Tests.InMemory
{
    public class RentalUnitOfWorkTests
    {
        public RentalUnitOfWorkTests()
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
        public async Task AddAsync_Should_AddClientToDb_When_MethodCalled()
        {
            var rental = new Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 15);

            await _sut.RentalRepository.AddAsync(rental, _cancellationToken);
            await _sut.SaveChangesAsync(_cancellationToken);

            var result = _testContext.Rentals.FirstOrDefault(x => x.Id == rental.Id);
            result.BoardGameId.Should().Be(rental.BoardGameId);
            result.ClientId.Should().Be(rental.ClientId);
        }

        [Fact]
        public void AddAsync_Should_ThrowArgumentException_When_ElementWithThisIdExist()
        {
            var rental = new Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 15);
            var existingEntity = new Persistence.Entities.Rental
            {
                Id = rental.Id
            };
            _testContext.Rentals.Add(existingEntity);
            _testContext.SaveChanges();

            Func<Task> act = async () =>
            {
                await _sut.RentalRepository.AddAsync(rental, _cancellationToken);
                await _sut.SaveChangesAsync(_cancellationToken);
            };

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task AreAllCompletedForBoardGameAsync_Should_ReturnFalse_When_ThereIsAnInProgressRental()
        {
            var boardGameId = Guid.NewGuid();
            var rentals = new List<Persistence.Entities.Rental>
            {
                new Persistence.Entities.Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.InProgress
                },
                new Persistence.Entities.Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                }
            };
            await _testContext.Rentals.AddRangeAsync(rentals, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var response =
                await _sut.RentalRepository.AreAllCompletedForBoardGameAsync(boardGameId, _cancellationToken);

            response.Should().BeFalse();
        }

        [Fact]
        public async Task AreAllCompletedForBoardGameAsync_Should_ReturnTrue_When_RentalsTableIsEmpty()
        {
            var boardGameId = Guid.NewGuid();

            var response =
                await _sut.RentalRepository.AreAllCompletedForBoardGameAsync(boardGameId, _cancellationToken);

            response.Should().BeTrue();
        }

        [Fact]
        public async Task AreAllCompletedForBoardGameAsync_Should_ReturnTrue_When_ThereAreOnlyCompletedRentals()
        {
            var boardGameId = Guid.NewGuid();
            var rentals = new List<Persistence.Entities.Rental>
            {
                new Persistence.Entities.Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                },
                new Persistence.Entities.Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                }
            };
            await _testContext.Rentals.AddRangeAsync(rentals, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var response =
                await _sut.RentalRepository.AreAllCompletedForBoardGameAsync(boardGameId, _cancellationToken);

            response.Should().BeTrue();
        }

        [Fact]
        public async Task AreAllCompletedForClientAsync_Should_ReturnFalse_When_ClientHasInProgressRental()
        {
            var clientId = Guid.NewGuid();
            var rentals = new List<Persistence.Entities.Rental>
            {
                new Persistence.Entities.Rental
                {
                    ClientId = clientId,
                    Status = Status.InProgress
                },
                new Persistence.Entities.Rental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                }
            };
            await _testContext.Rentals.AddRangeAsync(rentals, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var response = await _sut.RentalRepository.AreAllCompletedForClientAsync(clientId, _cancellationToken);

            response.Should().BeFalse();
        }

        [Fact]
        public async Task AreAllCompletedForClientAsync_Should_ReturnTrue_When_RentalsTableIsEmpty()
        {
            var clientId = Guid.NewGuid();

            var response = await _sut.RentalRepository.AreAllCompletedForClientAsync(clientId, _cancellationToken);

            response.Should().BeTrue();
        }

        [Fact]
        public async Task AreAllCompletedForClientAsync_Should_ReturnTrue_When_ThereAreOnlyCompletedRentals()
        {
            var clientId = Guid.NewGuid();

            var rentals = new List<Persistence.Entities.Rental>
            {
                new Persistence.Entities.Rental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                },
                new Persistence.Entities.Rental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                }
            };
            await _testContext.Rentals.AddRangeAsync(rentals, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var response = await _sut.RentalRepository.AreAllCompletedForClientAsync(clientId, _cancellationToken);

            response.Should().BeTrue();
        }

        [Fact]
        public async Task GetAllAsync_Should_ReturnEmptyListOfGameRentals_When_TableIsEmpty()
        {
            var result = await _sut.RentalRepository.GetAllAsync(_cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_Should_ReturnMappedListOfGameRentals_When_TheyHaveCorrectBoardGameId()
        {
            var inputBoardGameIdGuid = Guid.NewGuid();
            var entity1 = new Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                BoardGameId = inputBoardGameIdGuid
            };
            var entity2 = new Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                ClientId = inputBoardGameIdGuid
            };
            var entities = new List<Persistence.Entities.Rental> {entity1, entity2};
            await _testContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.RentalRepository.GetAllAsync(_cancellationToken);

            result.Should().BeOfType<List<Rental>>();
            result.Count.Should().Be(entities.Count);
        }

        [Fact]
        public async Task GetAllForBoardGameAsync_Should_ReturnEmptyListOfGameRentals_When_TableIsEmpty()
        {
            var input = Guid.NewGuid();

            var result = await _sut.RentalRepository.GetAllForBoardGameAsync(input, _cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllForBoardGameAsync_Should_ReturnMappedListOfGameRentals_When_TheyHaveCorrectBoardGameId()
        {
            var inputBoardGameIdGuid = Guid.NewGuid();
            var entity1 = new Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                BoardGameId = inputBoardGameIdGuid
            };
            var entity2 = new Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                ClientId = inputBoardGameIdGuid
            };
            var entities = new List<Persistence.Entities.Rental> {entity1, entity2};
            await _testContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.RentalRepository.GetAllForBoardGameAsync(inputBoardGameIdGuid, _cancellationToken);

            result.Should().BeOfType<List<Rental>>();
            result.Should().Contain(x => x.Id == entity1.Id);
            result.Should().NotContain(x => x.Id == entity2.Id);
            result.Count.Should().Be(1);
        }

        [Fact]
        public async Task GetAllForClientAsync_Should_ReturnEmptyListOfGameRentals_When_TableIsEmpty()
        {
            var input = Guid.NewGuid();

            var result = await _sut.RentalRepository.GetAllForClientAsync(input, _cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllForClientAsync_Should_ReturnMappedListOfGameRentals_When_TheyHaveCorrectBoardGameId()
        {
            var inputClientId = Guid.NewGuid();
            var entity1 = new Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                BoardGameId = inputClientId
            };
            var entity2 = new Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                ClientId = inputClientId
            };
            var entities = new List<Persistence.Entities.Rental> {entity1, entity2};
            await _testContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.RentalRepository.GetAllForClientAsync(inputClientId, _cancellationToken);

            result.Should().BeOfType<List<Rental>>();
            result.Should().NotContain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
            result.Count.Should().Be(1);
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnElementWithSpecificId()
        {
            var inputId = Guid.NewGuid();
            var entity1 = new Persistence.Entities.Rental
            {
                Id = inputId,
                PaidMoney = 10
            };
            var entity2 = new Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 20
            };
            var entities = new List<Persistence.Entities.Rental> {entity1, entity2};
            await _testContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.RentalRepository.GetByIdAsync(inputId, _cancellationToken);

            result.Id.Should().Be(inputId);
            result.PaidMoney.Should().Be(entity1.PaidMoney);
            result.Should().BeOfType<Rental>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnNull_When_NoMatchingElementsFound()
        {
            var entity1 = new Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 10
            };
            var entity2 = new Persistence.Entities.Rental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 20
            };
            var entities = new List<Persistence.Entities.Rental> {entity1, entity2};
            await _testContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.RentalRepository.GetByIdAsync(Guid.NewGuid(), _cancellationToken);

            result.Should().BeNull();
        }

        [Fact]
        public void Update_Should_Throw_When_EntityDoesNotExist()
        {
            var input = new Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 10);

            Func<Task> act = async () =>
            {
                await _sut.RentalRepository.Update(input);
                await _sut.SaveChangesAsync(_cancellationToken);
            };

            act.Should().Throw<DbUpdateConcurrencyException>();
        }

        [Fact]
        public async Task Update_Should_UpdateEntity_When_ItExists()
        {
            var input = new Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 10);
            var entities = new List<Persistence.Entities.Rental>
            {
                new Persistence.Entities.Rental
                {
                    Id = input.Id,
                    ClientId = Guid.NewGuid()
                },
                new Persistence.Entities.Rental
                {
                    Id = Guid.NewGuid(),
                    ClientId = Guid.NewGuid()
                }
            };
            await _testContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            await _sut.RentalRepository.Update(input);
            await _sut.SaveChangesAsync(_cancellationToken);

            _testContext.Rentals.Count().Should().Be(entities.Count);
            var result = _testContext.Rentals.FirstOrDefault(x => x.Id == input.Id);
            result.ClientId.Should().Be(input.ClientId);
            result.BoardGameId.Should().Be(input.BoardGameId);
        }
    }
}