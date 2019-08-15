using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Common;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models;
using Rental.DataAccess.CommandHandlers;
using Rental.DataAccess.Context;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
{
    public class UpdateAndSaveBoardGameCommandHandlerTests
    {
        public UpdateAndSaveBoardGameCommandHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new UpdateAndSaveBoardGameCommandHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly ICommandHandler<UpdateAndSaveBoardGameCommand> _sut;

        [Fact]
        public void Handle_Should_Throw_When_EntityDoesNotExist()
        {
            var input = new BoardGame(Guid.NewGuid(), "Test Updated", 20);

            Func<Task> act = async () =>
                await _sut.Handle(new UpdateAndSaveBoardGameCommand(input), new CancellationToken());

            act.Should().Throw<DbUpdateConcurrencyException>();
        }

        [Fact]
        public async Task Handle_Should_UpdateEntity_When_ItExists()
        {
            var input = new BoardGame(Guid.NewGuid(), "Test Updated", 20);
            var entities = new List<Entities.BoardGame>
            {
                new Entities.BoardGame
                {
                    Id = input.Id,
                    Name = "test1"
                },
                new Entities.BoardGame
                {
                    Id = Guid.NewGuid(),
                    Name = "test2"
                }
            };
            await _rentalContext.BoardGames.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            await _sut.Handle(new UpdateAndSaveBoardGameCommand(input), new CancellationToken());

            _rentalContext.BoardGames.Count().Should().Be(entities.Count);
            var result = _rentalContext.BoardGames.FirstOrDefault(x => x.Id == input.Id);
            result.Name.Should().Be(input.Name);
            result.Price.Should().Be(input.Price);
        }
    }
}