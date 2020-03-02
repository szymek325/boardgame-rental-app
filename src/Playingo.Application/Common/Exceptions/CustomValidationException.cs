using System;

namespace Playingo.Application.Common.Exceptions
{
    internal class CustomValidationException : Exception
    {
        public CustomValidationException(string validationMessage) : base(validationMessage)
        {
        }
    }
}