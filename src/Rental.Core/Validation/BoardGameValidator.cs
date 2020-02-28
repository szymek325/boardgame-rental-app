using System;
using FluentValidation;
using Playingo.Domain.BoardGames;

namespace Rental.Core.Validation
{
    internal class BoardGameValidator : AbstractValidator<BoardGame>
    {
        public BoardGameValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(2, 30)
                .NotEqual("string", StringComparer.CurrentCultureIgnoreCase);
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }

    internal interface IBoardGameValidator
    {
    }
}