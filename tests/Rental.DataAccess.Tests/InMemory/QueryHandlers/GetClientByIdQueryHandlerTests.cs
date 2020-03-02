// using System;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using AutoMapper;
// using FluentAssertions;
// using Microsoft.EntityFrameworkCore;
// using Playingo.Application.Clients.Queries;
// using Playingo.Application.Common.Mediator;
// using Playingo.Domain.Clients;
// using Playingo.Infrastructure.Persistence.Context;
// using Playingo.Infrastructure.Persistence.Mapping;
// using Playingo.Infrastructure.Persistence.QueryHandlers;
// using Xunit;
//
// namespace Rental.DataAccess.Tests.InMemory.QueryHandlers
// {
//     public class GetClientByIdQueryHandlerTests
//     {
//         public GetClientByIdQueryHandlerTests()
//         {
//             var contextOptions = new DbContextOptionsBuilder<PlayingoContext>()
//                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
//                 .Options;
//             _playingoContext = new PlayingoContext(contextOptions);
//             IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
//             _sut = new GetClientByIdQueryHandler(mapper, new PlayingoContext(contextOptions));
//         }
//
//         private readonly PlayingoContext _playingoContext;
//         private readonly IQueryHandler<GetClientByIdQuery, Client> _sut;
//
//         [Fact]
//         public async Task Handle_Should_ReturnElementWithSpecificId()
//         {
//             var inputId = Guid.NewGuid();
//             var entity1 = new Playingo.Infrastructure.Persistence.Entities.Client
//             {
//                 Id = inputId,
//                 FirstName = "test1"
//             };
//             var entity2 = new Playingo.Infrastructure.Persistence.Entities.Client
//             {
//                 Id = Guid.NewGuid(),
//                 FirstName = "test2"
//             };
//             var entities = new List<Playingo.Infrastructure.Persistence.Entities.Client> {entity1, entity2};
//             await _playingoContext.Clients.AddRangeAsync(entities);
//             await _playingoContext.SaveChangesAsync();
//
//             var result = await _sut.Handle(new GetClientByIdQuery(inputId), new CancellationToken());
//
//             result.Id.Should().Be(inputId);
//             result.FirstName.Should().Be(entity1.FirstName);
//             result.CreationTime.Should().Be(entity1.CreationTime);
//             result.Should().BeOfType<Client>();
//         }
//
//         [Fact]
//         public async Task Handle_Should_ReturnNull_When_NoMatchingElementsFound()
//         {
//             var entity1 = new Playingo.Infrastructure.Persistence.Entities.Client
//             {
//                 Id = Guid.NewGuid(),
//                 FirstName = "test1"
//             };
//             var entity2 = new Playingo.Infrastructure.Persistence.Entities.Client
//             {
//                 Id = Guid.NewGuid(),
//                 FirstName = "test2"
//             };
//             var entities = new List<Playingo.Infrastructure.Persistence.Entities.Client> {entity1, entity2};
//             await _playingoContext.Clients.AddRangeAsync(entities);
//             await _playingoContext.SaveChangesAsync();
//
//             var response = await _sut.Handle(new GetClientByIdQuery(Guid.NewGuid()), new CancellationToken());
//
//             response.Should().BeNull();
//         }
//     }
// }

