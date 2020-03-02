using FluentValidation;

namespace Playingo.Application.Validation
{
    internal class RentalValidator : AbstractValidator<Domain.Rentals.Rental>
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