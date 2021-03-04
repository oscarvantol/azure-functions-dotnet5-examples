using System;

namespace ExampleFunction
{
    public record TimerInfo(ScheduleStatus? ScheduleStatus, bool IsPastDue);
    public record ScheduleStatus(DateTime Last, DateTime Next, DateTime LastUpdated);
}
