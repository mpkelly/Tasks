using System;

namespace Tasks.Events
{
    public class RepeatingEvent : Event
    {
        public static RepeatingEvent DailyRepeatingEvent(DateTime startTime, DateTime endTime)
        {
            return new RepeatingEvent(startTime, endTime, 1);
        }

        public static RepeatingEvent WeeklyRepeatingEvent(DateTime startTime, DateTime endTime)
        {
            return new RepeatingEvent(startTime, endTime, 7);
        }

        public RepeatingEvent()
        {
            
        }

        private RepeatingEvent(DateTime startTime, DateTime endTime, int repeatInterval)
        {
            StartTime = startTime;
            EndTime = endTime;
            RepeatInterval = repeatInterval;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RepeatInterval { get; set; }

        public override bool OccursOnDate(DateTime date)
        {
            return IsInPeriod(date) && IsOnDay(date);
        }

        private bool IsOnDay(DateTime date)
        {
            var daysBetweenFirstAndCheckDate = (int) date.Subtract(StartTime.Date).TotalDays;
            return daysBetweenFirstAndCheckDate % RepeatInterval == 0;
        }

        private bool IsInPeriod(DateTime date)
        {
            return StartTime.Date <= date.Date && EndTime.Date >= date;
        }
    }
}