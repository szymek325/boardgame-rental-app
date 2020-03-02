// using System;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using AutoMapper;
// using FluentAssertions;
// using Microsoft.EntityFrameworkCore;
// using Playingo.Application.Common.Mediator;
// using Playingo.Application.Rentals.Queries;
// using Playingo.Infrastructure.Persistence.Context;
// using Playingo.Infrastructure.Persistence.Mapping;
// using Playingo.Infrastructure.Persistence.QueryHandlers;
// using Xunit;
//
// namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
// {
//     public class GetRentalByIdQueryHandlerTests
//     {
//         public GetRentalByIdQueryHandlerTests()
//         {
//             _playingoContext = new PlayingoContext(new DbContextOptionsBuilder<PlayingoContext>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options);
//             IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
//             _sut = new GetRentalByIdQueryHandler(mapper, _playingoContext);
//         }
//
//         private readonly PlayingoContext _playingoContext;
//         private readonly IQueryHandler<GetRentalByIdQuery, Playingo.Domain.Rentals.Rental> _sut;
//
//         [Fact]
//         public async Task Handle_Should_ReturnElementWithSpecificId()
//         {
//             var inputId = Guid.NewGuid();
//             var entity1 = new Playingo.Infrastructure.Persistence.Entities.Rental
//             {
//                 Id = inputId,
//                 PaidMoney = 10
//             };
//             var entity2 = new Playingo.Infrastructure.Persistence.Entities.Rental
//             {
//                 Id = Guid.NewGuid(),
//                 PaidMoney = 20
//             };
//             var entities = new List<Playingo.Infrastructure.Persistence.Entities.Rental> {entity1, entity2};
//             await _playingoContext.Rentals.AddRangeAsync(entities);
//             await _playingoContext.SaveChangesAsync();
//
//             var result = await _sut.Handle(new GetRentalByIdQuery(inputId), new CancellationToken());
//
//             result.Id.Should().Be(inputId);
//             result.PaidMoney.Should().Be(entity1.PaidMoney);
//             result.Should().BeOfType<Playingo.Domain.Rentals.Rental>();
//         }
//
//         [Fact]
//         public async Task Handle_Should_ReturnNull_When_NoMatchingElementsFound()
//         {
//             var entity1 = new Playingo.Infrastructure.Persistence.Entities.Rental
//             {
//                 Id = Guid.NewGuid(),
//                 PaidMoney = 10
//             };
//             var entity2 = new Playingo.Infrastructure.Persistence.Entities.Rental
//             {
//                 Id = Guid.NewGuid(),
//                 PaidMoney = 20
//             };
//             var entities = new List<Playingo.Infrastructure.Persistence.Entities.Rental> {entity1, entity2};
//             await _playingoContext.Rentals.AddRangeAsync(entities);
//             await _playingoContext.SaveChangesAsync();
//
//             var response = await _sut.Handle(new GetRentalByIdQuery(Guid.NewGuid()), new CancellationToken());
//
//             response.Should().BeNull();
//         }
//     }
// }

