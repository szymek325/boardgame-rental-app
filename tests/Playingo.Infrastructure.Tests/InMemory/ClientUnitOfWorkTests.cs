using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Playingo.Application.Common.Interfaces;
using Playingo.Domain.Clients;
using Playingo.Infrastructure.Persistence.Context;
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
            _testSetupContext = new PlayingoContext(contextOptions);
            _sut = new UnitOfWork(new PlayingoContext(contextOptions), mapper);
        }

        private readonly PlayingoContext _testSetupContext;
        private readonly IUnitOfWork _sut;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        [Fact]
        public async Task AddAsync_Should_AddClientToDb_When_MethodCalled()
        {
            var client = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");
            await _sut.ClientRepository.AddAsync(client, _cancellationToken);

            await _sut.SaveChangesAsync(_cancellationToken);

            var result = _testSetupContext.Clients.FirstOrDefault(x => x.Id == client.Id);
            result.ContactNumber.Should().Be(client.ContactNumber);
            result.EmailAddress.Should().Be(client.EmailAddress);
            result.FirstName.Should().Be(client.FirstName);
            result.LastName.Should().Be(client.LastName);
        }

        [Fact]
        public void AddAsync_Should_ThrowArgumentException_When_ElementWithThisIdExist()
        {
            var client = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");
            var existingEntity = new Persistence.Entities.Client
            {
                Id = client.Id
            };
            _testSetupContext.Clients.Add(existingEntity);
            _testSetupContext.SaveChanges();

            Func<Task> act = async () =>
            {
                await _sut.ClientRepository.AddAsync(client, _cancellationToken);
                await _sut.SaveChangesAsync(_cancellationToken);
            };

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task GetAllAsync_Should_ReturnEmptyListOfClients_When_ClientsTableIsEmpty()
        {
            var result = await _sut.ClientRepository.GetAllAsync(_cancellationToken);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllAsync_Should_ReturnMappedListOfClients_When_SomeExist()
        {
            var entity1 = new Persistence.Entities.Client
            {
                Id = Guid.NewGuid()
            };
            var entity2 = new Persistence.Entities.Client
            {
                Id = Guid.NewGuid()
            };
            var entities = new List<Persistence.Entities.Client> {entity1, entity2};
            await _testSetupContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _testSetupContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.ClientRepository.GetAllAsync(_cancellationToken);

            result.Should().Contain(x => x.Id == entity1.Id);
            result.Should().Contain(x => x.Id == entity2.Id);
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnElementWithSpecificId()
        {
            var inputId = Guid.NewGuid();
            var entity1 = new Persistence.Entities.Client
            {
                Id = inputId,
                FirstName = "test1"
            };
            var entity2 = new Persistence.Entities.Client
            {
                Id = Guid.NewGuid(),
                FirstName = "test2"
            };
            var entities = new List<Persistence.Entities.Client> {entity1, entity2};
            await _testSetupContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _testSetupContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.ClientRepository.GetByIdAsync(inputId, _cancellationToken);

            result.Id.Should().Be(inputId);
            result.FirstName.Should().Be(entity1.FirstName);
            result.CreationTime.Should().Be(entity1.CreationTime);
            result.Should().BeOfType<Client>();
        }

        [Fact]
        public async Task GetByIdAsync_Should_ReturnNull_When_NoMatchingElementsFound()
        {
            var entity1 = new Persistence.Entities.Client
            {
                Id = Guid.NewGuid(),
                FirstName = "test1"
            };
            var entity2 = new Persistence.Entities.Client
            {
                Id = Guid.NewGuid(),
                FirstName = "test2"
            };
            var entities = new List<Persistence.Entities.Client> {entity1, entity2};
            await _testSetupContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _testSetupContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.ClientRepository.GetByIdAsync(Guid.NewGuid(), _cancellationToken);

            result.Should().BeNull();
        }
    }
}