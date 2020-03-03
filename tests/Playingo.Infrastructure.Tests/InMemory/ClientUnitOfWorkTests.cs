using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Interfaces;
using Playingo.Infrastructure.Persistence.Context;
using Playingo.Infrastructure.Persistence.Entities;
using Playingo.Infrastructure.Persistence.Mapping;
using Playingo.Infrastructure.Persistence.Repositories;
using Xunit;

namespace Playingo.Infrastructure.Tests.InMemory
{
    public class ClientUnitOfWorkTests
    {
        public ClientUnitOfWorkTests()
        {
            var contextOptions = new DbContextOptionsBuilder<PlayingoContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _playingoContext = new PlayingoContext(contextOptions);
            _sut = new UnitOfWork(_playingoContext, mapper);
        }

        private readonly PlayingoContext _playingoContext;
        private readonly IUnitOfWork _sut;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        [Fact]
        public async Task GetAllAsync_Should_ReturnEmptyListOfClients_When_ClientsTableIsEmpty()
        {
            var result = await _sut.ClientRepository.GetAllAsync(_cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_Should_ReturnMappedListOfClients_When_SomeExist()
        {
            var entity1 = new Client
            {
                Id = Guid.NewGuid()
            };
            var entity2 = new Client
            {
                Id = Guid.NewGuid()
            };
            var entities = new List<Client> {entity1, entity2};
            await _playingoContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.ClientRepository.GetAllAsync(_cancellationToken);

            result.Should().Contain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnElementWithSpecificId()
        {
            var inputId = Guid.NewGuid();
            var entity1 = new Client
            {
                Id = inputId,
                FirstName = "test1"
            };
            var entity2 = new Client
            {
                Id = Guid.NewGuid(),
                FirstName = "test2"
            };
            var entities = new List<Client> {entity1, entity2};
            await _playingoContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.ClientRepository.GetByIdAsync(inputId, _cancellationToken);

            result.Id.Should().Be(inputId);
            result.FirstName.Should().Be(entity1.FirstName);
            result.CreationTime.Should().Be(entity1.CreationTime);
            result.Should().BeOfType<Domain.Clients.Client>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnNull_When_NoMatchingElementsFound()
        {
            var entity1 = new Client
            {
                Id = Guid.NewGuid(),
                FirstName = "test1"
            };
            var entity2 = new Client
            {
                Id = Guid.NewGuid(),
                FirstName = "test2"
            };
            var entities = new List<Client> {entity1, entity2};
            await _playingoContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _playingoContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.ClientRepository.GetByIdAsync(Guid.NewGuid(), _cancellationToken);

            result.Should().BeNull();
        }
    }
}