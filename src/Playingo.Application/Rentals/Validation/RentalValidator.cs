using FluentValidation;
using Playingo.Domain.Rentals;

namespace Playingo.Application.Rentals.Validation
{
    internal class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.ClientId).NotEmpty().NotNull();
            RuleFor(x => x.BoardGameId).NotEmpty().NotNull();
            RuleFor(x => (int) x.Status).GreaterThan(0);
        }
    }
}