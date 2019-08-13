using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;
using Rental.DataAccess.Handlers.BoardGameHandlers;
using Xunit;
using GameRental = Rental.DataAccess.Entities.GameRental;

namespace Rental.DataAccess.Tests.InMemory.BoardGameHandlers
{
    public class CheckIfBoardGameHasOnlyCompletedRentalsRequestHandlerTests
    {
        public CheckIfBoardGameHasOnlyCompletedRentalsRequestHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            _sut = new CheckIfBoardGameHasOnlyCompletedRentalsRequestHandler(new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly IRequestHandler<CheckIfBoardGameHasOnlyCompletedRentalsRequest, bool> _sut;

        [Fact]
        public async Task Handle_Should_ReturnFalse_When_ThereIsAnInProgressRental()
        {
            var boardGameId = Guid.NewGuid();
            var input = new CheckIfBoardGameHasOnlyCompletedRentalsRequest(boardGameId);
            var rentals = new List<GameRental>
            {
                new GameRental
                {
                    BoardGameId = boardGameId,
                    Status = Status.InProgress
                },
                new GameRental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                }
            };
            await _rentalContext.GameRentals.AddRangeAsync(rentals);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeFalse();
        }

        [Fact]
        public async Task Handle_Should_ReturnTrue_When_RentalsTableIsEmpty()
        {
            var boardGameId = Guid.NewGuid();
            var input = new CheckIfBoardGameHasOnlyCompletedRentalsRequest(boardGameId);

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_ReturnTrue_When_ThereAreOnlyCompletedRentals()
        {
            var boardGameId = Guid.NewGuid();
            var input = new CheckIfBoardGameHasOnlyCompletedRentalsRequest(boardGameId);
            var rentals = new List<GameRental>
            {
                new GameRental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                },
                new GameRental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                }
            };
            await _rentalContext.GameRentals.AddRangeAsync(rentals);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeTrue();
        }
    }
}