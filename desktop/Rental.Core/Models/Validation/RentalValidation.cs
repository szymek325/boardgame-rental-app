using FluentValidation;

namespace Rental.Core.Models.Validation
{
    internal class RentalValidation : AbstractValidator<GameRental>
    {
        public RentalValidation()
        {
            RuleFor(x => x.ClientId).NotEmpty().NotNull();
            RuleFor(x => x.BoardGameId).NotEmpty().NotNull();
            RuleFor(x => (int) x.Status).GreaterThan(0);
        }
    }

    internal class UpdateRentalValidator : RentalValidation
    {
        public UpdateRentalValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}