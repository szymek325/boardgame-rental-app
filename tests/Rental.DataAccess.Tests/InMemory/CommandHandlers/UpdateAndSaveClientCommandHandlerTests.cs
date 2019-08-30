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
    public class UpdateAndSaveClientCommandHandlerTests
    {
        public UpdateAndSaveClientCommandHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new UpdateAndSaveClientCommandHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly ICommandHandler<UpdateAndSaveClientCommand> _sut;

        [Fact]
        public void Handle_Should_Throw_When_EntityDoesNotExist()
        {
            var input = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");

            Func<Task> act = async () =>
                await _sut.Handle(new UpdateAndSaveClientCommand(input), new CancellationToken());

            act.Should().Throw<DbUpdateConcurrencyException>();
        }

        [Fact]
        public async Task Handle_Should_UpdateEntity_When_ItExists()
        {
            var input = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");
            var entities = new List<Entities.Client>
            {
                new Entities.Client
                {
                    Id = input.Id,
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

            await _sut.Handle(new UpdateAndSaveClientCommand(input), new CancellationToken());

            _rentalContext.Clients.Count().Should().Be(entities.Count);
            var result = _rentalContext.Clients.FirstOrDefault(x => x.Id == input.Id);
            result.FirstName.Should().Be(input.FirstName);
            result.LastName.Should().Be(input.LastName);
            result.ContactNumber.Should().Be(input.ContactNumber);
            result.EmailAddress.Should().Be(input.EmailAddress);
        }
    }
}