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
    public class GetClientByIdRequestHandlerTests
    {
        public GetClientByIdRequestHandlerTests()
        {
            _rentalContext = new RentalContext(new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetClientByIdRequestHandler(mapper, _rentalContext);
        }

        private readonly RentalContext _rentalContext;
        private readonly IRequestHandler<GetClientByIdRequest, Client> _sut;

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

            var result = await _sut.Handle(new GetClientByIdRequest(inputId), new CancellationToken());

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

            var response = await _sut.Handle(new GetClientByIdRequest(Guid.NewGuid()), new CancellationToken());

            response.Should().BeNull();
        }
    }
}