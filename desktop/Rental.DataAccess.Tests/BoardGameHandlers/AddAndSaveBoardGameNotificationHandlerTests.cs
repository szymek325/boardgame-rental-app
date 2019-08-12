using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;
using Rental.DataAccess.Handlers.BoardGameHandlers;
using Xunit;

namespace Rental.DataAccess.Tests.BoardGameHandlers
{
    public class AddAndSaveBoardGameNotificationHandlerTests
    {
        public AddAndSaveBoardGameNotificationHandlerTests()
        {
            _rentalContext = new RentalContext(new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            _mapper = new Mock<IMapper>(MockBehavior.Strict);
            _sut = new AddAndSaveBoardGameNotificationHandler(_mapper.Object, _rentalContext);
        }

        private readonly Mock<IMapper> _mapper;
        private readonly RentalContext _rentalContext;
        private readonly INotificationHandler<AddAndSaveBoardGameNotification> _sut;

        [Fact]
        public async Task Handle_Should_AddBoardGameToDb_When_MethodCalled()
        {
            var boardGame = new BoardGame("test", 15);
            var input = new AddAndSaveBoardGameNotification(boardGame);
            var entity = new Entities.BoardGame
            {
                Id = boardGame.Id,
                Name = boardGame.Name,
                Price = boardGame.Price,
                CreationTime = boardGame.CreationTime
            };
            _mapper.Setup(x => x.Map<Entities.BoardGame>(boardGame)).Returns(entity);

            await _sut.Handle(input, new CancellationToken());

            _rentalContext.BoardGames.SingleOrDefault(x => x.Id == entity.Id).Should().BeEquivalentTo(entity);
        }

        [Fact]
        public void Handle_Should_ThrowException_When_MapperThrows()
        {
            var boardGame = new BoardGame("test", 15);
            var input = new AddAndSaveBoardGameNotification(boardGame);
            _mapper.Setup(x => x.Map<Entities.BoardGame>(boardGame)).Throws<ArgumentException>();

            Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());

            act.Should().Throw<ArgumentException>();
            _rentalContext.BoardGames.Should().BeEmpty();
        }
    }
}