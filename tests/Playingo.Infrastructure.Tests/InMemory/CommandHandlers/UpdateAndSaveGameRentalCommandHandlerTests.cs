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
// using Playingo.Infrastructure.Persistence.CommandHandlers;
// using Playingo.Infrastructure.Persistence.Context;
// using Playingo.Infrastructure.Persistence.Mapping;
// using Xunit;
//
// namespace Playingo.Infrastructure.Tests.InMemory.CommandHandlers
// {
//     public class UpdateAndSaveGameRentalCommandHandlerTests
//     {
//         public UpdateAndSaveGameRentalCommandHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<Context>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _context = new Context(contextOptions);
//             IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
//             _sut = new UpdateAndSaveGameRentalCommandHandler(mapper, new Context(contextOptions));
//         }
//
//         private readonly Context _context;
//         private readonly ICommandHandler<UpdateAndSaveGameRentalCommand> _sut;
//
//         [Fact]
//         public void Handle_Should_Throw_When_EntityDoesNotExist()
//         {
//             var input = new Playingo.Domain.Rentals.Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 10);
//
//             Func<Task> act = async () =>
//                 await _sut.Handle(new UpdateAndSaveGameRentalCommand(input), new CancellationToken());
//
//             act.Should().Throw<DbUpdateConcurrencyException>();
//         }
//
//         [Fact]
//         public async Task Handle_Should_UpdateEntity_When_ItExists()
//         {
//             var input = new Playingo.Domain.Rentals.Rental(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 10);
//             var entities = new List<Playingo.Infrastructure.Persistence.Entities.Rental>
//             {
//                 new Playingo.Infrastructure.Persistence.Entities.Rental
//                 {
//                     Id = input.Id,
//                     ClientId = Guid.NewGuid()
//                 },
//                 new Playingo.Infrastructure.Persistence.Entities.Rental
//                 {
//                     Id = Guid.NewGuid(),
//                     ClientId = Guid.NewGuid()
//                 }
//             };
//             await _context.Rentals.AddRangeAsync(entities);
//             await _context.SaveChangesAsync();
//
//             await _sut.Handle(new UpdateAndSaveGameRentalCommand(input), new CancellationToken());
//
//             _context.Rentals.Count().Should().Be(entities.Count);
//             var result = _context.Rentals.FirstOrDefault(x => x.Id == input.Id);
//             result.ClientId.Should().Be(input.ClientId);
//             result.BoardGameId.Should().Be(input.BoardGameId);
//         }
//     }
// }

