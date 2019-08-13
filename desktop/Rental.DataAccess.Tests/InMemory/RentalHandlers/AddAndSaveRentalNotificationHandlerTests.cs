﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.GameRentalRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;
using Rental.DataAccess.Handlers.RentalHandlers;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.RentalHandlers
{
    public class AddAndSaveRentalNotificationHandlerTests
    {
        public AddAndSaveRentalNotificationHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new AddAndSaveRentalNotificationHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly INotificationHandler<AddAndSaveRentalNotification> _sut;

        [Fact]
        public async Task Handle_Should_AddClientToDb_When_MethodCalled()
        {
            var rental = new GameRental(Guid.NewGuid(), Guid.NewGuid(), 15);
            var input = new AddAndSaveRentalNotification(rental);

            await _sut.Handle(input, new CancellationToken());

            var result = _rentalContext.GameRentals.FirstOrDefault(x => x.Id == rental.Id);
            result.BoardGameId.Should().Be(rental.BoardGameId);
            result.ClientId.Should().Be(rental.ClientId);
        }

        [Fact]
        public void Handle_Should_ThrowArgumentException_When_ElementWithThisIdExist()
        {
            var rental = new GameRental(Guid.NewGuid(), Guid.NewGuid(), 15);
            var input = new AddAndSaveRentalNotification(rental);
            var existingEntity = new Entities.GameRental
            {
                Id = rental.Id
            };
            _rentalContext.GameRentals.Add(existingEntity);
            _rentalContext.SaveChanges();

            Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());

            act.Should().Throw<ArgumentException>();
        }
    }
}