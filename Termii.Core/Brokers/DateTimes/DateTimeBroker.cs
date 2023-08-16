



using System;

namespace Termii.Core.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset ConvertToDateTimeOffSet(int totalSeconds) =>
            DateTimeOffset.FromUnixTimeSeconds(totalSeconds);
    }
}
