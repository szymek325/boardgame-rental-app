using FluentValidation;

namespace Rental.Core.Common.Extensions
{
    public static class FluentValidationExtension
    {
        public static IRuleBuilderOptions<T, string> ContactNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new PhoneNumberValidator());
        }
    }
}