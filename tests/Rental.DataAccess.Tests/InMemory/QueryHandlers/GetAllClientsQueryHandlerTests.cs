using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Interfaces.DataAccess.Queries;
using Playingo.Domain.Clients;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.Mapping;
using Playingo.Infrastructure.Persistence.QueryHandlers;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
{
    public class GetAllClientsQueryHandlerTests
    {
        public GetAllClientsQueryHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetAllClientsQueryHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly IQueryHandler<GetAllClientsQuery, IList<Client>> _sut;

        [Fact]
        public async Task Handle_Should_ReturnEmptyListOfClients_When_ClientsTableIsEmpty()
        {
            var result = await _sut.Handle(new GetAllClientsQuery(), new CancellationToken());

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnMappedListOfClients_When_SomeExist()
        {
            var entity1 = new Playingo.Infrastructure.Persistence.Entities.Client
            {
                Id = Guid.NewGuid()
            };
            var entity2 = new Playingo.Infrastructure.Persistence.Entities.Client
            {
                Id = Guid.NewGuid()
            };
            var entities = new List<Playingo.Infrastructure.Persistence.Entities.Client> {entity1, entity2};
            await _rentalContext.Clients.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var result = await _sut.Handle(new GetAllClientsQuery(), new CancellationToken());

            result.Should().Contain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
        }
    }
}