﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Domain;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.QueryHandlers;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
{
    public class CheckIfBoardGameHasOnlyCompletedRentalsQueryHandlerTests
    {
        public CheckIfBoardGameHasOnlyCompletedRentalsQueryHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            _sut = new CheckIfBoardGameHasOnlyCompletedRentalsQueryHandler(new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly IQueryHandler<CheckIfBoardGameHasOnlyCompletedRentalsQuery, bool> _sut;

        [Fact]
        public async Task Handle_Should_ReturnFalse_When_ThereIsAnInProgressRental()
        {
            var boardGameId = Guid.NewGuid();
            var input = new CheckIfBoardGameHasOnlyCompletedRentalsQuery(boardGameId);
            var rentals = new List<Playingo.Infrastructure.Persistence.Entities.Rental>
            {
                new Playingo.Infrastructure.Persistence.Entities.Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.InProgress
                },
                new Playingo.Infrastructure.Persistence.Entities.Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                }
            };
            await _rentalContext.Rentals.AddRangeAsync(rentals);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeFalse();
        }

        [Fact]
        public async Task Handle_Should_ReturnTrue_When_RentalsTableIsEmpty()
        {
            var boardGameId = Guid.NewGuid();
            var input = new CheckIfBoardGameHasOnlyCompletedRentalsQuery(boardGameId);

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_ReturnTrue_When_ThereAreOnlyCompletedRentals()
        {
            var boardGameId = Guid.NewGuid();
            var input = new CheckIfBoardGameHasOnlyCompletedRentalsQuery(boardGameId);
            var rentals = new List<Playingo.Infrastructure.Persistence.Entities.Rental>
            {
                new Playingo.Infrastructure.Persistence.Entities.Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                },
                new Playingo.Infrastructure.Persistence.Entities.Rental
                {
                    BoardGameId = boardGameId,
                    Status = Status.Completed
                }
            };
            await _rentalContext.Rentals.AddRangeAsync(rentals);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(input, new CancellationToken());

            response.Should().BeTrue();
        }
    }
}