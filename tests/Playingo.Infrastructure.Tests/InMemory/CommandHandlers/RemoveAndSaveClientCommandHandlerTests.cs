// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using AutoMapper;
// using FluentAssertions;
// using Microsoft.EntityFrameworkCore;
// using Playingo.Application.Common.Mediator;
// using Playingo.Application.Interfaces.DataAccess.Commands;
// using Playingo.Domain.Clients;
// using Playingo.Infrastructure.Persistence.CommandHandlers;
// using Playingo.Infrastructure.Persistence.Context;
// using Playingo.Infrastructure.Persistence.Mapping;
// using Xunit;
//
// namespace Playingo.Infrastructure.Tests.InMemory.CommandHandlers
// {
//     public class RemoveAndSaveClientCommandHandlerTests
//     {
//         public RemoveAndSaveClientCommandHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<Context>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _context = new Context(contextOptions);
//             IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
//             _sut = new RemoveAndSaveClientCommandHandler(mapper, new Context(contextOptions));
//         }
//
//         private readonly Context _context;
//         private readonly ICommandHandler<RemoveAndSaveClientCommand> _sut;
//
//         [Fact]
//         public async Task Handle_Should_RemoveClientFromDb_When_ClientExists()
//         {
//             var client = new Client(Guid.NewGuid(), "First", "Last", "number", "email");
//             var entities = new List<Playingo.Infrastructure.Persistence.Entities.Client>
//             {
//                 new Playingo.Infrastructure.Persistence.Entities.Client
//                 {
//                     Id = client.Id,
//                     FirstName = "test1"
//                 },
//                 new Playingo.Infrastructure.Persistence.Entities.Client
//                 {
//                     Id = Guid.NewGuid(),
//                     FirstName = "test2"
//                 }
//             };
//             await _context.Clients.AddRangeAsync(entities);
//             await _context.SaveChangesAsync();
//
//             await _sut.Handle(new RemoveAndSaveClientCommand(client), new CancellationToken());
//
//             _context.Clients.Any(x => x.Id == client.Id).Should().BeFalse();
//         }
//
//         [Fact]
//         public void Handle_Should_ThrowDbUpdateConcurrencyException_When_ClientWithProvidedIdDoesNotExist()
//         {
//             var client = new Client(Guid.NewGuid(), "First", "Last", "number", "email");
//
//             Func<Task> act = async () =>
//                 await _sut.Handle(new RemoveAndSaveClientCommand(client), new CancellationToken());
//
//             act.Should().Throw<DbUpdateConcurrencyException>();
//         }
//     }
// }

