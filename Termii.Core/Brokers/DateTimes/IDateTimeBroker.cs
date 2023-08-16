



using System;

namespace Termii.Core.Brokers.DateTimes
{
    public interface IDateTimeBroker
    {
        DateTimeOffset ConvertToDateTimeOffSet(int totalSeconds);
    }
}
