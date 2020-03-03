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
//     public class UpdateAndSaveClientCommandHandlerTests
//     {
//         public UpdateAndSaveClientCommandHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<Context>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _context = new Context(contextOptions);
//             IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
//             _sut = new UpdateAndSaveClientCommandHandler(mapper, new Context(contextOptions));
//         }
//
//         private readonly Context _context;
//         private readonly ICommandHandler<UpdateAndSaveClientCommand> _sut;
//
//         [Fact]
//         public void Handle_Should_Throw_When_EntityDoesNotExist()
//         {
//             var input = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");
//
//             Func<Task> act = async () =>
//                 await _sut.Handle(new UpdateAndSaveClientCommand(input), new CancellationToken());
//
//             act.Should().Throw<DbUpdateConcurrencyException>();
//         }
//
//         [Fact]
//         public async Task Handle_Should_UpdateEntity_When_ItExists()
//         {
//             var input = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");
//             var entities = new List<Playingo.Infrastructure.Persistence.Entities.Client>
//             {
//                 new Playingo.Infrastructure.Persistence.Entities.Client
//                 {
//                     Id = input.Id,
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
//             await _sut.Handle(new UpdateAndSaveClientCommand(input), new CancellationToken());
//
//             _context.Clients.Count().Should().Be(entities.Count);
//             var result = _context.Clients.FirstOrDefault(x => x.Id == input.Id);
//             result.FirstName.Should().Be(input.FirstName);
//             result.LastName.Should().Be(input.LastName);
//             result.ContactNumber.Should().Be(input.ContactNumber);
//             result.EmailAddress.Should().Be(input.EmailAddress);
//         }
//     }
// }

