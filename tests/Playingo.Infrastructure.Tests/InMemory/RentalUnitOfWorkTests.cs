using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.Entities;
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
            _playingoContext = new PlayingoContext(contextOptions);
            _sut = new UnitOfWork(_playingoContext, mapper);
        }

        private readonly PlayingoContext _playingoContext;
        private readonly IUnitOfWork _sut;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        [Fact]
        public async Task AreAllCompletedForBoardGameAsync_Should_ReturnFalse_When_ThereIsAnInProgressRental()
        {
            var boardGameId = Guid.NewGuid();
            var rentals = new List<Rental>
            {
                new Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.InProgress
                },
                new Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                }
            };
            await _playingoContext.Rentals.AddRangeAsync(rentals, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

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
            var rentals = new List<Rental>
            {
                new Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                },
                new Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                }
            };
            await _playingoContext.Rentals.AddRangeAsync(rentals, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var response =
                await _sut.RentalRepository.AreAllCompletedForBoardGameAsync(boardGameId, _cancellationToken);

            response.Should().BeTrue();
        }

        [Fact]
        public async Task AreAllCompletedForClientAsync_Should_ReturnFalse_When_ClientHasInProgressRental()
        {
            var clientId = Guid.NewGuid();
            var rentals = new List<Rental>
            {
                new Rental
                {
                    ClientId = clientId,
                    Status = Status.InProgress
                },
                new Rental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                }
            };
            await _playingoContext.Rentals.AddRangeAsync(rentals, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

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

            var rentals = new List<Rental>
            {
                new Rental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                },
                new Rental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                }
            };
            await _playingoContext.Rentals.AddRangeAsync(rentals, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

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
            var entity1 = new Rental
            {
                Id = Guid.NewGuid(),
                BoardGameId = inputBoardGameIdGuid
            };
            var entity2 = new Rental
            {
                Id = Guid.NewGuid(),
                ClientId = inputBoardGameIdGuid
            };
            var entities = new List<Rental> {entity1, entity2};
            await _playingoContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.RentalRepository.GetAllAsync(_cancellationToken);

            result.Should().BeOfType<List<Domain.Rentals.Rental>>();
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
            var entity1 = new Rental
            {
                Id = Guid.NewGuid(),
                BoardGameId = inputBoardGameIdGuid
            };
            var entity2 = new Rental
            {
                Id = Guid.NewGuid(),
                ClientId = inputBoardGameIdGuid
            };
            var entities = new List<Rental> {entity1, entity2};
            await _playingoContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.RentalRepository.GetAllForBoardGameAsync(inputBoardGameIdGuid, _cancellationToken);

            result.Should().BeOfType<List<Domain.Rentals.Rental>>();
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
            var entity1 = new Rental
            {
                Id = Guid.NewGuid(),
                BoardGameId = inputClientId
            };
            var entity2 = new Rental
            {
                Id = Guid.NewGuid(),
                ClientId = inputClientId
            };
            var entities = new List<Rental> {entity1, entity2};
            await _playingoContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.RentalRepository.GetAllForClientAsync(inputClientId, _cancellationToken);

            result.Should().BeOfType<List<Domain.Rentals.Rental>>();
            result.Should().NotContain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
            result.Count.Should().Be(1);
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnElementWithSpecificId()
        {
            var inputId = Guid.NewGuid();
            var entity1 = new Rental
            {
                Id = inputId,
                PaidMoney = 10
            };
            var entity2 = new Rental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 20
            };
            var entities = new List<Rental> {entity1, entity2};
            await _playingoContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.RentalRepository.GetByIdAsync(inputId, _cancellationToken);

            result.Id.Should().Be(inputId);
            result.PaidMoney.Should().Be(entity1.PaidMoney);
            result.Should().BeOfType<Domain.Rentals.Rental>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnNull_When_NoMatchingElementsFound()
        {
            var entity1 = new Rental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 10
            };
            var entity2 = new Rental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 20
            };
            var entities = new List<Rental> {entity1, entity2};
            await _playingoContext.Rentals.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.RentalRepository.GetByIdAsync(Guid.NewGuid(), _cancellationToken);

            result.Should().BeNull();
        }
    }
}