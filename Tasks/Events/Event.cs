using System;

namespace Tasks.Events
{
    public enum EventState
    {
        Live, 
        Expired
    }

    public abstract class Event 
    {
        public TimeSpan Time { get; set; }
        public EventState EventState { get; set;}
        public long NextFireTime { get; set; }
        public long PreviousFireTime { get; set; }

        public abstract bool OccursOnDate(DateTime date);
    }
}
