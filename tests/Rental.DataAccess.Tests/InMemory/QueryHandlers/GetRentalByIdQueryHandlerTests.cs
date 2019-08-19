using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Queries;
using Rental.CQRS;
using Rental.DataAccess.Context;
using Rental.DataAccess.Mapping;
using Rental.DataAccess.QueryHandlers;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
{
    public class GetRentalByIdQueryHandlerTests
    {
        public GetRentalByIdQueryHandlerTests()
        {
            _rentalContext = new RentalContext(new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new GetRentalByIdQueryHandler(mapper, _rentalContext);
        }

        private readonly RentalContext _rentalContext;
        private readonly IQueryHandler<GetRentalByIdQuery, Core.Models.Rental> _sut;

        [Fact]
        public async Task Handle_Should_ReturnElementWithSpecificId()
        {
            var inputId = Guid.NewGuid();
            var entity1 = new Entities.Rental
            {
                Id = inputId,
                PaidMoney = 10
            };
            var entity2 = new Entities.Rental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 20
            };
            var entities = new List<Entities.Rental> {entity1, entity2};
            await _rentalContext.Rentals.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var result = await _sut.Handle(new GetRentalByIdQuery(inputId), new CancellationToken());

            result.Id.Should().Be(inputId);
            result.PaidMoney.Should().Be(entity1.PaidMoney);
            result.Should().BeOfType<Core.Models.Rental>();
        }

        [Fact]
        public async Task Handle_Should_ReturnNull_When_NoMatchingElementsFound()
        {
            var entity1 = new Entities.Rental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 10
            };
            var entity2 = new Entities.Rental
            {
                Id = Guid.NewGuid(),
                PaidMoney = 20
            };
            var entities = new List<Entities.Rental> {entity1, entity2};
            await _rentalContext.Rentals.AddRangeAsync(entities);
            await _rentalContext.SaveChangesAsync();

            var response = await _sut.Handle(new GetRentalByIdQuery(Guid.NewGuid()), new CancellationToken());

            response.Should().BeNull();
        }
    }
}