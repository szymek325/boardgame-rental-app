﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Rental.Core.Interfaces.DataAccess.Commands;
using Rental.CQRS;
using Rental.DataAccess.CommandHandlers;
using Rental.DataAccess.Context;
using Rental.DataAccess.Entities;
using Rental.DataAccess.Mapping;
using Xunit;

namespace Rental.DataAccess.Tests.InMemory.CommandHandlers
{
    public class RemoveAndSaveBoardGameCommandHandlerTests
    {
        public RemoveAndSaveBoardGameCommandHandlerTests()
        {
            var contextOptions = new DbContextOptionsBuilder<RentalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _rentalContext = new RentalContext(contextOptions);
            IMapper mapper = new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMapping>(); }));
            _sut = new RemoveAndSaveBoardGameCommandHandler(mapper,new RentalContext(contextOptions));
        }

        private readonly RentalContext _rentalContext;
        private readonly ICommandHandler<RemoveAndSaveBoardGameCommand> _sut;

        //[Fact]
        //public async Task Handle_Should_RemoveClientFromDb_When_ClientExists()
        //{
        //    var inputId = Guid.NewGuid();
        //    var entities = new List<BoardGame>
        //    {
        //        new BoardGame
        //        {
        //            Id = inputId,
        //            Name = "test1"
        //        },
        //        new BoardGame
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "test2"
        //        }
        //    };
        //    await _rentalContext.BoardGames.AddRangeAsync(entities);
        //    await _rentalContext.SaveChangesAsync();

        //    await _sut.Handle(new RemoveAndSaveBoardGameCommand(inputId), new CancellationToken());

        //    _rentalContext.BoardGames.FirstOrDefault(x => x.Id == inputId).Should().BeNull();
        //}

        //[Fact]
        //public void Handle_Should_ThrowDbUpdateConcurrencyException_When_BoardGameWithProvidedIdDoesNotExist()
        //{
        //    var input = Guid.NewGuid();

        //    Func<Task> act = async () =>
        //        await _sut.Handle(new RemoveAndSaveBoardGameCommand(input), new CancellationToken());

        //    act.Should().Throw<DbUpdateConcurrencyException>();
        //}
    }
}