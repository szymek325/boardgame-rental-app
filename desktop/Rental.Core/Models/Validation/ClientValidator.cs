using FluentValidation;
using Rental.Core.Extensions;

namespace Rental.Core.Models.Validation
{
    internal class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.ContactNumber).ContactNumber();
        }
    }

    internal class UpdateClientValidator : ClientValidator
    {
        public UpdateClientValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEmpty();
        }
    }
}