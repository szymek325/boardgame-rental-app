// using System;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using AutoMapper;
// using FluentAssertions;
// using Microsoft.EntityFrameworkCore;
// using Playingo.Application.BoardGames.Queries;
// using Playingo.Application.Common.Mediator;
// using Playingo.Domain.BoardGames;
// using Playingo.Infrastructure.Persistence.Context;
// using Playingo.Infrastructure.Persistence.Mapping;
// using Playingo.Infrastructure.Persistence.QueryHandlers;
// using Xunit;
//
// namespace Playingo.Infrastructure.Tests.InMemory.QueryHandlers
// {
//     public class GetAllBoardGamesQueryHandlerTests
//     {
//         public GetAllBoardGamesQueryHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<PlayingoContext>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _playingoContext = new PlayingoContext(contextOptions);
//             IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
//             _sut = new GetAllBoardGamesQueryHandler(mapper, new PlayingoContext(contextOptions));
//         }
//
//         private readonly PlayingoContext _playingoContext;
//         private readonly IQueryHandler<GetAllBoardGamesQuery, IList<BoardGame>> _sut;
//
//         [Fact]
//         public async Task Handle_Should_ReturnEmptyListOfBoardGames_When_BoardGamesTableIsEmpty()
//         {
//             var result = await _sut.Handle(new GetAllBoardGamesQuery(), new CancellationToken());
//
//             result.Should().BeEmpty();
//         }
//
//         [Fact]
//         public async Task Handle_Should_ReturnMappedListOfGameBoards_When_SomeExist()
//         {
//             var entity1 = new Playingo.Infrastructure.Persistence.Entities.BoardGame
//             {
//                 Id = Guid.NewGuid()
//             };
//             var entity2 = new Playingo.Infrastructure.Persistence.Entities.BoardGame
//             {
//                 Id = Guid.NewGuid()
//             };
//             var entities = new List<Playingo.Infrastructure.Persistence.Entities.BoardGame> {entity1, entity2};
//             await _playingoContext.BoardGames.AddRangeAsync(entities);
//             await _playingoContext.SaveChangesAsync();
//
//             var result = await _sut.Handle(new GetAllBoardGamesQuery(), new CancellationToken());
//
//             result.Should().Contain(x => x.Id == entity1.Id);
//             result.Should().Contain(x => x.Id == entity2.Id);
//         }
//     }
// }

