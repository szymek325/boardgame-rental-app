using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Playingo.Domain.BoardGames;
using Rental.CQS;
using Rental.DataAccess.CommandHandlers;
using Rental.DataAccess.Context;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
{
    public class RemoveAndSaveBoardGameCommandHandlerTests
    {
        public RemoveAndSaveBoardGameCommandHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new RemoveAndSaveBoardGameCommandHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly ICommandHandler<RemoveAndSaveBoardGameCommand> _sut;

        [Fact]
        public async Task Handle_Should_RemoveClientFromDb_When_ClientExists()
        {
            var boardGame = new BoardGame(Guid.NewGuid(), "SomeGame", 15);
            var entities = new List<Entities.BoardGame>
            {
                new Entities.BoardGame
                {
                    Id = boardGame.Id,
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

            await _sut.Handle(new RemoveAndSaveBoardGameCommand(boardGame), new CancellationToken());

            _rentalContext.BoardGames.Any(x => x.Id == boardGame.Id).Should().BeFalse();
        }

        [Fact]
        public void Handle_Should_ThrowDbUpdateConcurrencyException_When_BoardGameWithProvidedIdDoesNotExist()
        {
            var boardGame = new BoardGame(Guid.NewGuid(), "SomeGame", 15);

            Func<Task> act = async () =>
                await _sut.Handle(new RemoveAndSaveBoardGameCommand(boardGame), new CancellationToken());

            act.Should().Throw<DbUpdateConcurrencyException>();
        }
    }
}