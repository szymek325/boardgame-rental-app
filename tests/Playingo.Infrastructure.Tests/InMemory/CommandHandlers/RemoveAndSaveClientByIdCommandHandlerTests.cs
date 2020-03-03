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
// namespace Playingo.Infrastructure.Tests.InMemory.CommandHandlers
// {
//     public class RemoveAndSaveClientByIdCommandHandlerTests
//     {
//         public RemoveAndSaveClientByIdCommandHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<Context>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _context = new Context(contextOptions);
//             _sut = new RemoveAndSaveClientByIdCommandHandler(new Context(contextOptions));
//         }
//
//         private readonly Context _context;
//         private readonly ICommandHandler<RemoveAndSaveClientByIdCommand> _sut;
//
//         [Fact]
//         public async Task Handle_Should_RemoveClientFromDb_When_ClientExists()
//         {
//             var inputId = Guid.NewGuid();
//             var entities = new List<Client>
//             {
//                 new Client
//                 {
//                     Id = inputId,
//                     FirstName = "test1"
//                 },
//                 new Client
//                 {
//                     Id = Guid.NewGuid(),
//                     FirstName = "test2"
//                 }
//             };
//             await _context.Clients.AddRangeAsync(entities);
//             await _context.SaveChangesAsync();
//
//             await _sut.Handle(new RemoveAndSaveClientByIdCommand(inputId), new CancellationToken());
//
//             _context.Clients.FirstOrDefault(x => x.Id == inputId).Should().BeNull();
//         }
//
//         [Fact]
//         public void Handle_Should_ThrowArgumentNullException_When_ClientWithProvidedIdDoesNotExist()
//         {
//             var input = Guid.NewGuid();
//
//             Func<Task> act = async () =>
//                 await _sut.Handle(new RemoveAndSaveClientByIdCommand(input), new CancellationToken());
//
//             act.Should().Throw<ArgumentNullException>();
//         }
//     }
// }

