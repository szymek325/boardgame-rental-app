using System.Text.RegularExpressions;
using FluentValidation.Resources;
using FluentValidation.Validators;

namespace Rental.Core.Common.Extensions
{
    public interface IPhoneNumberValidator : IRegularExpressionValidator, IPropertyValidator
    {
    }

    public class PhoneNumberValidator : PropertyValidator, IRegularExpressionValidator, IPropertyValidator,
        IPhoneNumberValidator
    {
        private readonly Regex _regex;

        public PhoneNumberValidator()
            : base(new LanguageStringSource(nameof(PhoneNumberValidator)))
        {
            _regex = new Regex(Expression);
        }

        public string Expression => "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$";

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return context.PropertyValue == null || _regex.IsMatch((string) context.PropertyValue);
        }
    }
}