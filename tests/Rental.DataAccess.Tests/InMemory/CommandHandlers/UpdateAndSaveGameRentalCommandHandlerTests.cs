using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Rental.DataAccess.CommandHandlers;
using Rental.DataAccess.Context;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
{
    public class UpdateAndSaveGameRentalCommandHandlerTests
    {
        public UpdateAndSaveGameRentalCommandHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new UpdateAndSaveGameRentalCommandHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly ICommandHandler<UpdateAndSaveGameRentalCommand> _sut;

        [Fact]
        public void Handle_Should_Throw_When_EntityDoesNotExist()
        {
            var input = new Playingo.Domain.Rentals.Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 10);

            Func<Task> act = async () =>
                await _sut.Handle(new UpdateAndSaveGameRentalCommand(input), new CancellationToken());

            act.Should().Throw<DbUpdateConcurrencyException>();
        }

        [Fact]
        public async Task Handle_Should_UpdateEntity_When_ItExists()
        {
            var input = new Playingo.Domain.Rentals.Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 10);
            var entities = new List<Entities.Rental>
            {
                new Entities.Rental
                {
                    Id = input.Id,
                    ClientId = Guid.NewGuid()
                },
                new Entities.Rental
                {
                    Id = Guid.NewGuid(),
                    ClientId = Guid.NewGuid()
                }
            };
            await _rentalContext.Rentals.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            await _sut.Handle(new UpdateAndSaveGameRentalCommand(input), new CancellationToken());

            _rentalContext.Rentals.Count().Should().Be(entities.Count);
            var result = _rentalContext.Rentals.FirstOrDefault(x => x.Id == input.Id);
            result.ClientId.Should().Be(input.ClientId);
            result.BoardGameId.Should().Be(input.BoardGameId);
        }
    }
}