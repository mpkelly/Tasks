using System;

namespace Tasks.Events
{
    public class MonthlyRepeatingEvent : RepeatingEvent
    {
        public MonthlyRepeatingEvent(int dayOfMonth, DateTime startTime, DateTime endTime) : base (startTime, endTime)
        {
            DayOfMonth = dayOfMonth;
        }

        public int DayOfMonth { get; set; }

        //Check if the day matches the input date. If not, check if the input date is the last in the month
        //and less than this event's DayOfMonth. This allows for last day of month events setup as, say 31st, to fire
        //on February 28th (or 29th for leap years). 
        protected override bool IsOnDay(DateTime date)
        {
            if (date.Day == DayOfMonth)
                return true;
            return date.Day == DateTime.DaysInMonth(date.Year, date.Month) && DayOfMonth > date.Day;
        }
    }
}