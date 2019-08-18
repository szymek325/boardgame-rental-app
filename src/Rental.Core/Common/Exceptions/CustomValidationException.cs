using System;

namespace Rental.Core.Common.Exceptions
{
    internal class CustomValidationException : Exception
    {
        public CustomValidationException(string validationMessage) : base(validationMessage)
        {
        }
    }
}