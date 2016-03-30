using System.Collections.Generic;
using Tasks.Scheduling;

namespace Tasks.Events
{
    public interface IEventStore
    {
        Event FindNextEventInPeriod(Period period);
        List<Event> FindAllMisfiredEvents();
        void Save(Event @event);
        void Remove(Event @event);
        void Expire(Event @event);
    }
}