using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models;
using Rental.DataAccess.Context;
using Rental.DataAccess.Handlers.Commands;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.RentalHandlers
{
    public class UpdateAndSaveGameRentalNotificationHandlerTests
    {
        public UpdateAndSaveGameRentalNotificationHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new UpdateAndSaveGameRentalCommandHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly INotificationHandler<UpdateAndSaveGameRentalCommand> _sut;

        [Fact]
        public void Handle_Should_Throw_When_EntityDoesNotExist()
        {
            var input = new GameRental(Guid.NewGuid(), Guid.NewGuid(), 10);

            Func<Task> act = async () =>
                await _sut.Handle(new UpdateAndSaveGameRentalCommand(input), new CancellationToken());

            act.Should().Throw<DbUpdateConcurrencyException>();
        }

        [Fact]
        public async Task Handle_Should_UpdateEntity_When_ItExists()
        {
            var input = new GameRental(Guid.NewGuid(), Guid.NewGuid(), 10);
            var entities = new List<Entities.GameRental>
            {
                new Entities.GameRental
                {
                    Id = input.Id,
                    ClientId = Guid.NewGuid()
                },
                new Entities.GameRental
                {
                    Id = Guid.NewGuid(),
                    ClientId = Guid.NewGuid()
                }
            };
            await _rentalContext.GameRentals.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            await _sut.Handle(new UpdateAndSaveGameRentalCommand(input), new CancellationToken());

            _rentalContext.GameRentals.Count().Should().Be(entities.Count);
            var result = _rentalContext.GameRentals.FirstOrDefault(x => x.Id == input.Id);
            result.ClientId.Should().Be(input.ClientId);
            result.BoardGameId.Should().Be(input.BoardGameId);
        }
    }
}