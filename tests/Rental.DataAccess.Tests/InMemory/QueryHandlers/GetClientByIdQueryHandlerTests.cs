using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.Core.Models.Clients;
using Rental.CQS;
using Rental.DataAccess.Context;
using Rental.DataAccess.Mapping;
using Rental.DataAccess.QueryHandlers;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
{
    public class GetClientByIdQueryHandlerTests
    {
        public GetClientByIdQueryHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetClientByIdQueryHandler(mapper, new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly IQueryHandler<GetClientByIdQuery, Client> _sut;

        [Fact]
        public async Task Handle_Should_ReturnElementWithSpecificId()
        {
            var inputId = Guid.NewGuid();
            var entity1 = new Entities.Client
            {
                Id = inputId,
                FirstName = "test1"
            };
            var entity2 = new Entities.Client
            {
                Id = Guid.NewGuid(),
                FirstName = "test2"
            };
            var entities = new List<Entities.Client> {entity1, entity2};
            await _rentalContext.Clients.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var result = await _sut.Handle(new GetClientByIdQuery(inputId), new CancellationToken());

            result.Id.Should().Be(inputId);
            result.FirstName.Should().Be(entity1.FirstName);
            result.CreationTime.Should().Be(entity1.CreationTime);
            result.Should().BeOfType<Client>();
        }

        [Fact]
        public async Task Handle_Should_ReturnNull_When_NoMatchingElementsFound()
        {
            var entity1 = new Entities.Client
            {
                Id = Guid.NewGuid(),
                FirstName = "test1"
            };
            var entity2 = new Entities.Client
            {
                Id = Guid.NewGuid(),
                FirstName = "test2"
            };
            var entities = new List<Entities.Client> {entity1, entity2};
            await _rentalContext.Clients.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(new GetClientByIdQuery(Guid.NewGuid()), new CancellationToken());

            response.Should().BeNull();
        }
    }
}