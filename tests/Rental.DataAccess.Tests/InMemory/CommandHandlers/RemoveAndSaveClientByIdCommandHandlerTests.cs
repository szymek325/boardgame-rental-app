using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Commands;
using Rental.DataAccess.CommandHandlers;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
{
    public class RemoveAndSaveClientByIdCommandHandlerTests
    {
        public RemoveAndSaveClientByIdCommandHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            _sut = new RemoveAndSaveClientByIdCommandHandler(new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly ICommandHandler<RemoveAndSaveClientByIdCommand> _sut;

        [Fact]
        public async Task Handle_Should_RemoveClientFromDb_When_ClientExists()
        {
            var inputId = Guid.NewGuid();
            var entities = new List<Client>
            {
                new Client
                {
                    Id = inputId,
                    FirstName = "test1"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test2"
                }
            };
            await _rentalContext.Clients.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            await _sut.Handle(new RemoveAndSaveClientByIdCommand(inputId), new CancellationToken());

            _rentalContext.Clients.FirstOrDefault(x => x.Id == inputId).Should().BeNull();
        }

        [Fact]
        public void Handle_Should_ThrowArgumentNullException_When_ClientWithProvidedIdDoesNotExist()
        {
            var input = Guid.NewGuid();

            Func<Task> act = async () =>
                await _sut.Handle(new RemoveAndSaveClientByIdCommand(input), new CancellationToken());

            act.Should().Throw<ArgumentNullException>();
        }
    }
}