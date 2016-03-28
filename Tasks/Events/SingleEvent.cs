using System;

namespace Tasks.Events
{
    public class SingleEvent : Event
    {
        public SingleEvent(DateTime date)
        {
            Date = date;
            Time = date.TimeOfDay;
        }

        public DateTime Date { get; set; }

        public override bool OccursOnDate(DateTime date)
        {
            return Date.Date == date.Date;
        }
    }
}
