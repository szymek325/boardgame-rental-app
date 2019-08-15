using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;
using Rental.DataAccess.Handlers.Commands;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.ClientHandlers
{
    public class RemoveAndSaveClientNotificationHandlerTests
    {
        public RemoveAndSaveClientNotificationHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            _sut = new RemoveAndSaveClientCommandHandler(new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly INotificationHandler<RemoveAndSaveClientCommand> _sut;

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

            await _sut.Handle(new RemoveAndSaveClientCommand(inputId), new CancellationToken());

            _rentalContext.Clients.FirstOrDefault(x => x.Id == inputId).Should().BeNull();
        }

        [Fact]
        public void Handle_Should_ThrowDbUpdateConcurrencyException_When_ClientWithProvidedIdDoesNotExist()
        {
            var input = Guid.NewGuid();

            Func<Task> act = async () =>
                await _sut.Handle(new RemoveAndSaveClientCommand(input), new CancellationToken());

            act.Should().Throw<DbUpdateConcurrencyException>();
        }
    }
}