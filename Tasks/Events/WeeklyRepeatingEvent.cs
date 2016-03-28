using System;

namespace Tasks.Events
{
    public class WeeklyRepeatingEvent : RepeatingEvent
    {
        public WeeklyRepeatingEvent(DaysOfWeek daysOfWeek, DateTime startDate, DateTime endDate) : base (startDate, endDate)
        {
            DaysOfWeek = daysOfWeek;
        }

        public DaysOfWeek DaysOfWeek { get; set; }

        protected override bool IsOnDay(DateTime time)
        {
            return IsInPeriod(time) && DaysOfWeek.IsDayOfWeekSelected(time.DayOfWeek);
        }
    }


    //A bridge to C#'s DayOfWeek class that allows for bitwise operations and also allows 
    //for storing multiple days as a single value, avoiding 1-n relationships that aren't supported by SQLIte.NET
    [Flags]
    public enum DaysOfWeek
    {
        None = 0,
        Sunday = 1 << DayOfWeek.Sunday,
        Monday = 1 << DayOfWeek.Monday,
        Tuesday = 1 << DayOfWeek.Tuesday,
        Wednesday = 1 << DayOfWeek.Wednesday,
        Thursday = 1 << DayOfWeek.Thursday,
        Friday = 1 << DayOfWeek.Friday,
        Saturday = 1 << DayOfWeek.Saturday
    }

    public static class DaysOfWeekExtensions
    {
        public static bool IsDayOfWeekSelected(this DaysOfWeek which, DayOfWeek dayOfWeek)
        {
            var day = (DaysOfWeek) (1 << (int) dayOfWeek);
            return  (which & day) == day;
        }
    }
}