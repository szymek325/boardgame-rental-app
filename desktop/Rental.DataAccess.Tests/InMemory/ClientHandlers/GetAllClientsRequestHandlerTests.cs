using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.ClientRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;
using Rental.DataAccess.Handlers.ClientHandlers;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.ClientHandlers
{
    public class GetAllClientsRequestHandlerTests
    {
        public GetAllClientsRequestHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetAllClientsRequestHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly IRequestHandler<GetAllClientsRequest, IList<Client>> _sut;

        [Fact]
        public async Task Handle_Should_ReturnEmptyListOfClients_When_ClientsTableIsEmpty()
        {
            var result = await _sut.Handle(new GetAllClientsRequest(), new CancellationToken());

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnMappedListOfClients_When_SomeExist()
        {
            var entity1 = new Entities.Client
            {
                Id = Guid.NewGuid()
            };
            var entity2 = new Entities.Client
            {
                Id = Guid.NewGuid()
            };
            var entities = new List<Entities.Client> {entity1, entity2};
            await _rentalContext.Clients.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var result = await _sut.Handle(new GetAllClientsRequest(), new CancellationToken());

            result.Should().Contain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
        }
    }
}