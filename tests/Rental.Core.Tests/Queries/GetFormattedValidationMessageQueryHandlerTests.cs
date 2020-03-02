using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation.Results;
using Playingo.Application.Common.Mediator;
using Playingo.Application.Validation;
using Xunit;

namespace Rental.Core.Tests.Queries
{
    public class GetFormattedValidationMessageQueryHandlerTests
    {
        public GetFormattedValidationMessageQueryHandlerTests()
        {
            sut = new GetFormattedValidationMessageQueryHandler();
        }

        private readonly IQueryHandler<GetFormattedValidationMessageQuery, string> sut;

        [Fact]
        public async Task Handle_Should_ContainEachFailure_When_SomeFailuresArePassed()
        {
            var failure1 = new ValidationFailure("test1", "failure on something");
            var failure2 = new ValidationFailure("test2", "failure on something else");
            var input = new List<ValidationFailure> {failure1, failure2};

            var result = await sut.Handle(new GetFormattedValidationMessageQuery(input),
                new CancellationToken());

            result.Should().Contain($"{failure1.PropertyName}- {failure1.ErrorMessage}");
            result.Should().Contain($"{failure2.PropertyName}- {failure2.ErrorMessage}");
        }


        [Fact]
        public async Task Handle_Should_ReturnEmptyMessage_When_ListIsEmpty()
        {
            var input = new List<ValidationFailure>();

            var result = await sut.Handle(new GetFormattedValidationMessageQuery(input),
                new CancellationToken());

            result.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Handle_Should_ReturnEmptyMessage_When_ListIsEmpty2()
        {
            List<ValidationFailure> input = null;

            Func<Task> act = async () => await sut.Handle(new GetFormattedValidationMessageQuery(input),
                new CancellationToken());

            act.Should().Throw<NullReferenceException>();
        }
    }
}