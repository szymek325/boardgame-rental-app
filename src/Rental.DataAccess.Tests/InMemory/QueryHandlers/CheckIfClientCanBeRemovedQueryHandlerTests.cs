using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models;
using Rental.CQRS;
using Rental.DataAccess.Context;
using Rental.DataAccess.QueryHandlers;
using Xunit;
using Client = Rental.DataAccess.Entities.Client;
using GameRental = Rental.DataAccess.Entities.GameRental;

namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
{
    public class CheckIfClientCanBeRemovedQueryHandlerTests
    {
        public CheckIfClientCanBeRemovedQueryHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            _sut = new CheckIfClientCanBeRemovedQueryHandler(new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly IQueryHandler<CheckIfClientCanBeRemovedQuery, bool> _sut;

        [Fact]
        public async Task Handle_Should_ReturnFalse_When_ClientDoesNotExist()
        {
            var clientId = Guid.NewGuid();
            var input = new CheckIfClientCanBeRemovedQuery(clientId);
            var rentals = new List<GameRental>
            {
                new GameRental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                },
                new GameRental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                }
            };
            await _rentalContext.GameRentals.AddRangeAsync(rentals);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeFalse();
        }

        [Fact]
        public async Task Handle_Should_ReturnFalse_When_ClientHasInProgressRental()
        {
            var clientId = Guid.NewGuid();
            var input = new CheckIfClientCanBeRemovedQuery(clientId);
            var client = new Client
            {
                Id = clientId,
                FirstName = "Name1"
            };
            var rentals = new List<GameRental>
            {
                new GameRental
                {
                    ClientId = clientId,
                    Status = Status.InProgress
                },
                new GameRental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                }
            };
            await _rentalContext.GameRentals.AddRangeAsync(rentals);
            await _rentalContext.AddAsync(client);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeFalse();
        }

        [Fact]
        public async Task Handle_Should_ReturnTrue_When_RentalsTableIsEmpty()
        {
            var clientId = Guid.NewGuid();
            var input = new CheckIfClientCanBeRemovedQuery(clientId);
            var client = new Client
            {
                Id = clientId,
                FirstName = "Name1"
            };
            await _rentalContext.AddAsync(client);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_ReturnTrue_When_ThereAreOnlyCompletedRentals()
        {
            var clientId = Guid.NewGuid();
            var input = new CheckIfClientCanBeRemovedQuery(clientId);
            var client = new Client
            {
                Id = clientId,
                FirstName = "Name1"
            };
            var rentals = new List<GameRental>
            {
                new GameRental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                },
                new GameRental
                {
                    ClientId = clientId,
                    Status = Status.Completed
                }
            };
            await _rentalContext.GameRentals.AddRangeAsync(rentals);
            await _rentalContext.Clients.AddAsync(client);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeTrue();
        }
    }
}