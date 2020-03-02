// using System;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using AutoMapper;
// using FluentAssertions;
// using Microsoft.EntityFrameworkCore;
// using Playingo.Application.Common.Mediator;
// using Playingo.Application.Interfaces.DataAccess.Commands;
// using Playingo.Infrastructure.Persistence.CommandHandlers;
// using Playingo.Infrastructure.Persistence.Context;
// using Playingo.Infrastructure.Persistence.Mapping;
// using Xunit;
//
// namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
// {
//     public class AddAndSaveRentalCommandHandlerTests
//     {
//         public AddAndSaveRentalCommandHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<Context>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _context = new Context(contextOptions);
//             IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
//             _sut = new AddAndSaveRentalCommandHandler(mapper, new Context(contextOptions));
//         }
//
//         private readonly Context _context;
//         private readonly ICommandHandler<AddAndSaveRentalCommand> _sut;
//
//         [Fact]
//         public async Task Handle_Should_AddClientToDb_When_MethodCalled()
//         {
//             var rental = new Playingo.Domain.Rentals.Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 15);
//             var input = new AddAndSaveRentalCommand(rental);
//
//             await _sut.Handle(input, new CancellationToken());
//
//             var result = _context.Rentals.FirstOrDefault(x => x.Id == rental.Id);
//             result.BoardGameId.Should().Be(rental.BoardGameId);
//             result.ClientId.Should().Be(rental.ClientId);
//         }
//
//         [Fact]
//         public void Handle_Should_ThrowArgumentException_When_ElementWithThisIdExist()
//         {
//             var rental = new Playingo.Domain.Rentals.Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 15);
//             var input = new AddAndSaveRentalCommand(rental);
//             var existingEntity = new Playingo.Infrastructure.Persistence.Entities.Rental
//             {
//                 Id = rental.Id
//             };
//             _context.Rentals.Add(existingEntity);
//             _context.SaveChanges();
//
//             Func<Task> act = async () => await _sut.Handle(input, new CancellationToken());
//
//             act.Should().Throw<ArgumentException>();
//         }
//     }
// }

