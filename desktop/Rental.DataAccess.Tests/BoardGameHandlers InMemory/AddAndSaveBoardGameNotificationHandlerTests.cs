using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.BoardGameRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;
using Rental.DataAccess.Handlers.BoardGameHandlers;
using Rental.DataAccess.Mapping;
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
            _mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new AddAndSaveBoardGameNotificationHandler(_mapper, _rentalContext);
        }

        private readonly IMapper _mapper;
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

            await _sut.Handle(input, new CancellationToken());

            _rentalContext.BoardGames.SingleOrDefault(x => x.Id == entity.Id).Should().BeEquivalentTo(entity);
        }
    }
}