using System;

namespace ExampleFunction
{
    public record TimerInfo1(ScheduleStatus? ScheduleStatus, bool IsPastDue);
    public record ScheduleStatus(DateTime Last, DateTime Next, DateTime LastUpdated);
}
