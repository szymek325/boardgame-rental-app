using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models;
using Rental.DataAccess.CommandHandlers;
using Rental.DataAccess.Context;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
{
    public class AddAndSaveBoardGameCommandHandlerTests
    {
        public AddAndSaveBoardGameCommandHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            _mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new AddAndSaveBoardGameCommandHandler(_mapper, new RentalContext(contextOptions));
        }

        private readonly IMapper _mapper;
        private readonly RentalContext _rentalContext;
        private readonly INotificationHandler<AddAndSaveBoardGameCommand> _sut;

        [Fact]
        public async Task Handle_Should_AddBoardGameToDb_When_MethodCalled()
        {
            var boardGame = new BoardGame(Guid.NewGuid(), "test", 15);
            var input = new AddAndSaveBoardGameCommand(boardGame);
            var entity = new Entities.BoardGame
            {
                Id = boardGame.Id,
                Name = boardGame.Name,
                Price = boardGame.Price,
                CreationTime = boardGame.CreationTime
            };

            await _sut.Handle(input, new CancellationToken());

            _rentalContext.BoardGames.SingleOrDefault(x => x.Id == boardGame.Id).Should().BeEquivalentTo(entity);
        }

        [Fact]
        public void Handle_Should_ThrowArgumentException_When_ElementWithThisIdExist()
        {
            var boardGame = new BoardGame(Guid.NewGuid(), "test", 15);
            var input = new AddAndSaveBoardGameCommand(boardGame);
            var existingEntity = new Entities.BoardGame
            {
                Id = boardGame.Id
            };
            _rentalContext.BoardGames.Add(existingEntity);
            _rentalContext.SaveChanges();

            Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());

            act.Should().Throw<ArgumentException>();
        }
    }
}