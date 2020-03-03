using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.Results;
using Playingo.Application.Validation;
using Xunit;

namespace Playingo.Application.Tests.Validation
{
    public class ValidationMessageBuilderTests
    {
        public ValidationMessageBuilderTests()
        {
            sut = new ValidationMessageBuilder();
        }

        private readonly IValidationMessageBuilder sut;

        [Fact]
        public void Handle_Should_ContainEachFailure_When_SomeFailuresArePassed()
        {
            var failure1 = new ValidationFailure("test1", "failure on something");
            var failure2 = new ValidationFailure("test2", "failure on something else");
            var input = new List<ValidationFailure> {failure1, failure2};

            var result = sut.CreateMessage(input);

            result.Should().Contain($"{failure1.PropertyName}- {failure1.ErrorMessage}");
            result.Should().Contain($"{failure2.PropertyName}- {failure2.ErrorMessage}");
        }


        [Fact]
        public void Handle_Should_ReturnEmptyMessage_When_ListIsEmpty()
        {
            var input = new List<ValidationFailure>();

            var result = sut.CreateMessage(input);

            result.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Handle_Should_ReturnEmptyMessage_When_ListIsEmpty2()
        {
            List<ValidationFailure> input = null;

            Action act = () => sut.CreateMessage(input);

            act.Should().Throw<NullReferenceException>();
        }
    }
}