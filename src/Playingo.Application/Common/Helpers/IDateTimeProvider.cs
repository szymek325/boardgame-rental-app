using System;

namespace Playingo.Application.Common.Helpers
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }

    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}