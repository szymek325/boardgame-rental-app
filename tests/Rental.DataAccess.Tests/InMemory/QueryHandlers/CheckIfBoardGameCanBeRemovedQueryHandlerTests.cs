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
using BoardGame = Rental.DataAccess.Entities.BoardGame;
using GameRental = Rental.DataAccess.Entities.GameRental;

namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
{
    public class CheckIfBoardGameCanBeRemovedQueryHandlerTests
    {
        public CheckIfBoardGameCanBeRemovedQueryHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            _sut = new CheckIfBoardGameCanBeRemovedQueryHandler(new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly IQueryHandler<CheckIfBoardGameCanBeRemovedQuery, bool> _sut;

        [Fact]
        public async Task Handle_Should_ReturnFalse_When_BoardGameDoesnNotExist()
        {
            var boardGameId = Guid.NewGuid();
            var input = new CheckIfBoardGameCanBeRemovedQuery(boardGameId);
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

            response.Should().BeFalse();
        }

        [Fact]
        public async Task Handle_Should_ReturnFalse_When_ThereIsAnInProgressRental()
        {
            var boardGameId = Guid.NewGuid();
            var input = new CheckIfBoardGameCanBeRemovedQuery(boardGameId);
            var boardGame = new BoardGame
            {
                Id = boardGameId,
                Name = "test"
            };
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
            await _rentalContext.BoardGames.AddAsync(boardGame);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeFalse();
        }

        [Fact]
        public async Task Handle_Should_ReturnTrue_When_RentalsTableIsEmpty()
        {
            var boardGameId = Guid.NewGuid();
            var input = new CheckIfBoardGameCanBeRemovedQuery(boardGameId);
            var boardGame = new BoardGame
            {
                Id = boardGameId,
                Name = "test"
            };
            await _rentalContext.BoardGames.AddAsync(boardGame);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_ReturnTrue_When_ThereAreOnlyCompletedRentals()
        {
            var boardGameId = Guid.NewGuid();
            var input = new CheckIfBoardGameCanBeRemovedQuery(boardGameId);
            var boardGame = new BoardGame
            {
                Id = boardGameId,
                Name = "test"
            };
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
            await _rentalContext.BoardGames.AddAsync(boardGame);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeTrue();
        }
    }
}