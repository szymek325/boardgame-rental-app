using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.CQS;
using Rental.DataAccess.CommandHandlers;
using Rental.DataAccess.Context;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
{
    public class AddAndSaveRentalCommandHandlerTests
    {
        public AddAndSaveRentalCommandHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new AddAndSaveRentalCommandHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly ICommandHandler<AddAndSaveRentalCommand> _sut;

        [Fact]
        public async Task Handle_Should_AddClientToDb_When_MethodCalled()
        {
            var rental = new Playingo.Domain.Rentals.Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 15);
            var input = new AddAndSaveRentalCommand(rental);

            await _sut.Handle(input, new CancellationToken());

            var result = _rentalContext.Rentals.FirstOrDefault(x => x.Id == rental.Id);
            result.BoardGameId.Should().Be(rental.BoardGameId);
            result.ClientId.Should().Be(rental.ClientId);
        }

        [Fact]
        public void Handle_Should_ThrowArgumentException_When_ElementWithThisIdExist()
        {
            var rental = new Playingo.Domain.Rentals.Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 15);
            var input = new AddAndSaveRentalCommand(rental);
            var existingEntity = new Entities.Rental
            {
                Id = rental.Id
            };
            _rentalContext.Rentals.Add(existingEntity);
            _rentalContext.SaveChanges();

            Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());

            act.Should().Throw<ArgumentException>();
        }
    }
}