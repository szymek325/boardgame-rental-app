using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.GameRentalRequests;
using Rental.Core.Models;
using Rental.DataAccess.Context;
using Rental.DataAccess.Handlers.RentalHandlers;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.RentalHandlers
{
    public class GetRentalByIdRequestHandlerTests
    {
        public GetRentalByIdRequestHandlerTests()
        {
            _rentalContext = new RentalContext(new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetRentalByIdRequestHandler(mapper, _rentalContext);
        }

        private readonly RentalContext _rentalContext;
        private readonly IRequestHandler<GetRentalByIdRequest, GameRental> _sut;

        [Fact]
        public async Task Handle_Should_ReturnElementWithSpecificId()
        {
            var inputId = Guid.NewGuid();
            var entity1 = new Entities.GameRental
            {
                Id = inputId,
                PaidMoney = 10
            };
            var entity2 = new Entities.GameRental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 20
            };
            var entities = new List<Entities.GameRental> {entity1, entity2};
            await _rentalContext.GameRentals.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var result = await _sut.Handle(new GetRentalByIdRequest(inputId), new CancellationToken());

            result.Id.Should().Be(inputId);
            result.PaidMoney.Should().Be(entity1.PaidMoney);
            result.Should().BeOfType<GameRental>();
        }

        [Fact]
        public async Task Handle_Should_ReturnNull_When_NoMatchingElementsFound()
        {
            var entity1 = new Entities.GameRental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 10
            };
            var entity2 = new Entities.GameRental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 20
            };
            var entities = new List<Entities.GameRental> {entity1, entity2};
            await _rentalContext.GameRentals.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(new GetRentalByIdRequest(Guid.NewGuid()), new CancellationToken());

            response.Should().BeNull();
        }
    }
}