using System;
using FluentValidation;
using Playingo.Application.Common.Extensions;
using Playingo.Domain.Clients;

namespace Playingo.Application.Validation
{
    internal class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().NotNull().Length(2, 30)
                .NotEqual("string", StringComparer.CurrentCultureIgnoreCase);
            RuleFor(x => x.LastName).NotEmpty().NotNull().Length(2, 30)
                .NotEqual("string", StringComparer.CurrentCultureIgnoreCase);
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.ContactNumber).ContactNumber();
        }
    }
}