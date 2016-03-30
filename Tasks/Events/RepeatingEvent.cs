using System;

namespace Tasks.Events
{
    public abstract class RepeatingEvent : Event
    {
        protected RepeatingEvent(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public override bool OccursOnDate(DateTime date)
        {
            return IsInPeriod(date) && IsOnDay(date);
        }

        protected bool IsInPeriod(DateTime date)
        {
            return StartTime.Date <= date.Date && EndTime.Date >= date;
        }

        protected abstract bool IsOnDay(DateTime time);
    }
}