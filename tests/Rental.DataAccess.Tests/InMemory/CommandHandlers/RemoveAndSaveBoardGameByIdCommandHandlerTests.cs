// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using FluentAssertions;
// using Microsoft.EntityFrameworkCore;
// using Playingo.Application.Common.Mediator;
// using Playingo.Application.Interfaces.DataAccess.Commands;
// using Playingo.Infrastructure.Persistence.CommandHandlers;
// using Playingo.Infrastructure.Persistence.Context;
// using Playingo.Infrastructure.Persistence.Entities;
// using Xunit;
//
// namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
// {
//     public class RemoveAndSaveBoardGameByIdCommandHandlerTests
//     {
//         public RemoveAndSaveBoardGameByIdCommandHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<Context>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _context = new Context(contextOptions);
//             _sut = new RemoveAndSaveBoardGameByIdCommandHandler(new Context(contextOptions));
//         }
//
//         private readonly Context _context;
//         private readonly ICommandHandler<RemoveAndSaveBoardGameByIdCommand> _sut;
//
//         [Fact]
//         public async Task Handle_Should_RemoveClientFromDb_When_ClientExists()
//         {
//             var inputId = Guid.NewGuid();
//             var entities = new List<BoardGame>
//             {
//                 new BoardGame
//                 {
//                     Id = inputId,
//                     Name = "test1"
//                 },
//                 new BoardGame
//                 {
//                     Id = Guid.NewGuid(),
//                     Name = "test2"
//                 }
//             };
//             await _context.BoardGames.AddRangeAsync(entities);
//             await _context.SaveChangesAsync();
//
//             await _sut.Handle(new RemoveAndSaveBoardGameByIdCommand(inputId), new CancellationToken());
//
//             _context.BoardGames.FirstOrDefault(x => x.Id == inputId).Should().BeNull();
//         }
//
//         [Fact]
//         public void Handle_Should_ThrowArgumentNullException_When_BoardGameWithProvidedIdDoesNotExist()
//         {
//             var input = Guid.NewGuid();
//
//             Func<Task> act = async () =>
//                 await _sut.Handle(new RemoveAndSaveBoardGameByIdCommand(input), new CancellationToken());
//
//             act.Should().Throw<ArgumentNullException>();
//         }
//     }
// }

