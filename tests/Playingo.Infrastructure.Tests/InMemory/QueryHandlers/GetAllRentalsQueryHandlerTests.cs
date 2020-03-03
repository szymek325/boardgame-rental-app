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
// namespace Playingo.Infrastructure.Tests.InMemory.QueryHandlers
// {
//     public class GetAllRentalsQueryHandlerTests
//     {
//         public GetAllRentalsQueryHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<PlayingoContext>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _playingoContext = new PlayingoContext(contextOptions);
//             IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
//             _sut = new GetAllRentalsQueryHandler(mapper, new PlayingoContext(contextOptions));
//         }
//
//         private readonly PlayingoContext _playingoContext;
//         private readonly IQueryHandler<GetAllRentalsQuery, IList<Playingo.Domain.Rentals.Rental>> _sut;
//
//         [Fact]
//         public async Task Handle_Should_ReturnEmptyListOfGameRentals_When_TableIsEmpty()
//         {
//             var result = await _sut.Handle(new GetAllRentalsQuery(), new CancellationToken());
//
//             result.Should().BeEmpty();
//         }
//
//         [Fact]
//         public async Task Handle_Should_ReturnMappedListOfGameRentals_When_TheyHaveCorrectBoardGameId()
//         {
//             var inputBoardGameIdGuid = Guid.NewGuid();
//             var entity1 = new Playingo.Infrastructure.Persistence.Entities.Rental
//             {
//                 Id = Guid.NewGuid(),
//                 BoardGameId = inputBoardGameIdGuid
//             };
//             var entity2 = new Playingo.Infrastructure.Persistence.Entities.Rental
//             {
//                 Id = Guid.NewGuid(),
//                 ClientId = inputBoardGameIdGuid
//             };
//             var entities = new List<Playingo.Infrastructure.Persistence.Entities.Rental> {entity1, entity2};
//             await _playingoContext.Rentals.AddRangeAsync(entities);
//             await _playingoContext.SaveChangesAsync();
//
//             var result = await _sut.Handle(new GetAllRentalsQuery(), new CancellationToken());
//
//             result.Should().BeOfType<List<Playingo.Domain.Rentals.Rental>>();
//             result.Count.Should().Be(entities.Count);
//         }
//     }
// }

