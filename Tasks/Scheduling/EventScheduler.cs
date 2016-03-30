using System;
using System.Timers;
using Tasks.Events;
using Timer = System.Timers.Timer;

namespace Tasks.Scheduling
{
    public delegate void OnEventFired(Event @event);

    public class EventScheduler
    {
        public event OnEventFired OnEventFired;

        private readonly IEventStore eventStore;
        private readonly Period period;
        private Timer timer;

        public EventScheduler(IEventStore eventStore, Period period)
        {
            this.eventStore = eventStore;
            this.period = period;
        }

        public void Start()
        {
            timer = new Timer();
            HandleMisfires();
            var @event = LoadEventsForPeriod();
            WaitForNextEvent(@event);
        }

        public void Stop()
        {
            timer.Stop();
            timer.Dispose();
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        private void WaitForNextEvent(Event @event)
        {
            var nextFireTime = @event?.NextFireTime ?? period.EndTime;
            var timeUntilNextEvent = nextFireTime - DateTime.UtcNow.Ticks;
            ElapsedEventHandler handler = delegate { EventFired(@event); };

            timer.Elapsed += handler;
            timer.Interval = timeUntilNextEvent;
            timer.Start();
        }

        private void EventFired(Event @event)
        {
            OnEventFired(@event);
        }

        private Event LoadEventsForPeriod()
        {
            return eventStore.FindNextEventInPeriod(period);
        }

        private void HandleMisfires()
        {
            
        }
    }
}
