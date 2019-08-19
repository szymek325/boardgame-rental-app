using FluentValidation;

namespace Rental.Core.Models.Validation
{
    internal class RentalValidator : AbstractValidator<Rentals.Rental>
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