using System;

namespace Tasks.Events
{
    public class NDaysRepeatingEvent : RepeatingEvent
    {
        public static RepeatingEvent DailyRepeatingEvent(DateTime startTime, DateTime endTime)
        {
            return new NDaysRepeatingEvent(1, startTime, endTime);
        }

        public NDaysRepeatingEvent(int repeatInterval, DateTime startTime, DateTime endTime) : base (startTime, endTime)
        {
            RepeatInterval = repeatInterval;
        }

        public int RepeatInterval { get; set; }

        protected override bool IsOnDay(DateTime date)
        {
            var daysBetweenFirstAndCheckDate = (int) date.Subtract(StartTime.Date).TotalDays;
            return daysBetweenFirstAndCheckDate % RepeatInterval == 0;            
        }
    }
}
