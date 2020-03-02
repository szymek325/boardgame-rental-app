// using System;
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
// namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
// {
//     public class AddAndSaveClientCommandHandlerTests
//     {
//         public AddAndSaveClientCommandHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<Context>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _context = new Context(contextOptions);
//             IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
//             _sut = new AddAndSaveClientCommandHandler(mapper, new Context(contextOptions));
//         }
//
//         private readonly Context _context;
//         private readonly ICommandHandler<AddAndSaveClientCommand> _sut;
//
//         [Fact]
//         public async Task Handle_Should_AddClientToDb_When_MethodCalled()
//         {
//             var client = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");
//             var input = new AddAndSaveClientCommand(client);
//
//             await _sut.Handle(input, new CancellationToken());
//
//             var result = _context.Clients.FirstOrDefault(x => x.Id == client.Id);
//             result.ContactNumber.Should().Be(client.ContactNumber);
//             result.EmailAddress.Should().Be(client.EmailAddress);
//             result.FirstName.Should().Be(client.FirstName);
//             result.LastName.Should().Be(client.LastName);
//         }
//
//         [Fact]
//         public void Handle_Should_ThrowArgumentException_When_ElementWithThisIdExist()
//         {
//             var client = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");
//             var input = new AddAndSaveClientCommand(client);
//             var existingEntity = new Playingo.Infrastructure.Persistence.Entities.Client
//             {
//                 Id = client.Id
//             };
//             _context.Clients.Add(existingEntity);
//             _context.SaveChanges();
//
//             Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());
//
//             act.Should().Throw<ArgumentException>();
//         }
//     }
// }

