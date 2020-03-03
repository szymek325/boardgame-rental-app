// using System;
// using System.Linq;
// using System.Threading.Tasks;
// using AutoMapper;
// using FluentAssertions;
// using Microsoft.EntityFrameworkCore;
// using Playingo.Application.Common.Interfaces;
// using Playingo.Domain.BoardGames;
// using Playingo.Infrastructure.Persistence.Context;
// using Playingo.Infrastructure.Persistence.Mapping;
// using Playingo.Infrastructure.Persistence.Repositories;
// using Xunit;
//
// namespace Playingo.Infrastructure.Tests.InMemory.CommandHandlers
// {
//     public class AddAndSaveBoardGameCommandHandlerTests
//     {
//         public AddAndSaveBoardGameCommandHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<Context>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _context = new Context(contextOptions);
//             IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
//             _sut = new UnitOfWork(new Context(contextOptions), mapper);
//         }
//
//         private readonly Context _context;
//         private readonly IUnitOfWork _sut;
//
//         [Fact]
//         public async Task Handle_Should_AddBoardGameToDb_When_MethodCalled()
//         {
//             var boardGame = new BoardGame(Guid.NewGuid(), "test", 15);
//             var entity = new Playingo.Infrastructure.Persistence.Entities.BoardGame
//             {
//                 Id = boardGame.Id,
//                 Name = boardGame.Name,
//                 Price = boardGame.Price,
//                 CreationTime = boardGame.CreationTime
//             };
//
//             await _sut.BoardGameRepository.AddAsync(boardGame);
//             await _sut.SaveChangesAsync();
//
//             _context.BoardGames.SingleOrDefault(x => x.Id == boardGame.Id).Should().BeEquivalentTo(entity);
//         }
//
//         [Fact]
//         public void Handle_Should_ThrowArgumentException_When_ElementWithThisIdExist()
//         {
//             var boardGame = new BoardGame(Guid.NewGuid(), "test", 15);
//             var existingEntity = new Playingo.Infrastructure.Persistence.Entities.BoardGame
//             {
//                 Id = boardGame.Id
//             };
//             _context.BoardGames.Add(existingEntity);
//             _context.SaveChanges();
//
//             Func<Task> act = async () => await _sut.BoardGameRepository.AddAsync(boardGame);
//
//             act.Should().Throw<ArgumentException>();
//         }
//     }
// }

