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
            _testContext = new PlayingoContext(contextOptions);
            _sut = new UnitOfWork(new PlayingoContext(contextOptions), mapper);
        }

        private readonly PlayingoContext _testContext;
        private readonly IUnitOfWork _sut;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        [Fact]
        public async Task AddAsync_Should_AddClientToDb_When_MethodCalled()
        {
            var client = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");
            await _sut.ClientRepository.AddAsync(client, _cancellationToken);

            await _sut.SaveChangesAsync(_cancellationToken);

            var result = _testContext.Clients.FirstOrDefault(x => x.Id == client.Id);
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
            _testContext.Clients.Add(existingEntity);
            _testContext.SaveChanges();

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
            await _testContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

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
            await _testContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

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
            await _testContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            var result = await _sut.ClientRepository.GetByIdAsync(Guid.NewGuid(), _cancellationToken);

            result.Should().BeNull();
        }

        [Fact]
        public async Task RemoveById_Should_RemoveClientFromDb_When_ClientExists()
        {
            var inputId = Guid.NewGuid();
            var entities = new List<Persistence.Entities.Client>
            {
                new Persistence.Entities.Client
                {
                    Id = inputId,
                    FirstName = "test1"
                },
                new Persistence.Entities.Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test2"
                }
            };
            await _testContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            await _sut.ClientRepository.RemoveByIdAsync(inputId, _cancellationToken);
            await _sut.SaveChangesAsync(_cancellationToken);

            _testContext.Clients.FirstOrDefault(x => x.Id == inputId).Should().BeNull();
        }

        [Fact]
        public void RemoveById_Should_ThrowArgumentNullException_When_ClientWithProvidedIdDoesNotExist()
        {
            var input = Guid.NewGuid();

            Func<Task> act = async () =>
            {
                await _sut.ClientRepository.RemoveByIdAsync(input, _cancellationToken);
                await _sut.SaveChangesAsync(_cancellationToken);
            };

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Update_Should_Throw_When_EntityDoesNotExist()
        {
            var input = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");

            Func<Task> act = async () =>
            {
                await _sut.ClientRepository.Update(input);
                await _sut.SaveChangesAsync(_cancellationToken);
            };

            act.Should().Throw<DbUpdateConcurrencyException>();
        }

        [Fact]
        public async Task Update_Should_UpdateEntity_When_ItExists()
        {
            var input = new Client(Guid.NewGuid(), "mat", "szym", "123456", "test@test.pl");
            var entities = new List<Persistence.Entities.Client>
            {
                new Persistence.Entities.Client
                {
                    Id = input.Id,
                    FirstName = "test1"
                },
                new Persistence.Entities.Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test2"
                }
            };
            await _testContext.Clients.AddRangeAsync(entities, _cancellationToken);
            await _testContext.SaveChangesAsync(_cancellationToken);

            await _sut.ClientRepository.Update(input);
            await _sut.SaveChangesAsync(_cancellationToken);

            _testContext.Clients.Count().Should().Be(entities.Count);
            var result = _testContext.Clients.FirstOrDefault(x => x.Id == input.Id);
            result.FirstName.Should().Be(input.FirstName);
            result.LastName.Should().Be(input.LastName);
            result.ContactNumber.Should().Be(input.ContactNumber);
            result.EmailAddress.Should().Be(input.EmailAddress);
        }
    }
}