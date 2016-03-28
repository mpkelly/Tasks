using System;

namespace Tasks.Events
{
    public abstract class Event 
    {
        public TimeSpan Time { get; set; }
        public abstract bool OccursOnDate(DateTime date);
    }
}
