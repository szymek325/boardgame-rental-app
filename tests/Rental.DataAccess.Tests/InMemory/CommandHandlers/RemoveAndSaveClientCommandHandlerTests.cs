using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.Core.Models.Clients;
using Rental.CQS;
using Rental.DataAccess.CommandHandlers;
using Rental.DataAccess.Context;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
{
    public class RemoveAndSaveClientCommandHandlerTests
    {
        public RemoveAndSaveClientCommandHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new RemoveAndSaveClientCommandHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly ICommandHandler<RemoveAndSaveClientCommand> _sut;

        [Fact]
        public async Task Handle_Should_RemoveClientFromDb_When_ClientExists()
        {
            var client = new Client(Guid.NewGuid(), "First", "Last", "number", "email");
            var entities = new List<Entities.Client>
            {
                new Entities.Client
                {
                    Id = client.Id,
                    FirstName = "test1"
                },
                new Entities.Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test2"
                }
            };
            await _rentalContext.Clients.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            await _sut.Handle(new RemoveAndSaveClientCommand(client), new CancellationToken());

            _rentalContext.Clients.Any(x => x.Id == client.Id).Should().BeFalse();
        }

        [Fact]
        public void Handle_Should_ThrowDbUpdateConcurrencyException_When_ClientWithProvidedIdDoesNotExist()
        {
            var client = new Client(Guid.NewGuid(), "First", "Last", "number", "email");

            Func<Task> act = async () =>
                await _sut.Handle(new RemoveAndSaveClientCommand(client), new CancellationToken());

            act.Should().Throw<DbUpdateConcurrencyException>();
        }
    }
}