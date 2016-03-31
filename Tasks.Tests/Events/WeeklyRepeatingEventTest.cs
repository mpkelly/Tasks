using System;
using NUnit.Framework;
using Tasks.Events;
using static NUnit.Framework.Assert;

namespace Tasks.Test.Events
{
    public class WeeklyRepeatingEventTest : AbstractEventTest
    {
        [Test]
        public void weekly_repating_event_when_day_matches()
        {
            var days = DaysOfWeek.Monday | DaysOfWeek.Friday;
            var weeklyEvent = new WeeklyRepeatingEvent(days, FirstOfJanuary2015, ThirtyFirstOfJanuary2015);

            IsTrue(weeklyEvent.OccursOnDate(new DateTime(2015, 1, 2)), "Friday 2nd January");
            IsTrue(weeklyEvent.OccursOnDate(new DateTime(2015, 1, 5)), "Monday 5nd January");
        }

        [Test]
        public void weekly_repeating_event_when_day_does_not_match()
        {
            var days = DaysOfWeek.Monday | DaysOfWeek.Friday;
            var weeklyEvent = new WeeklyRepeatingEvent(days, FirstOfJanuary2015, ThirtyFirstOfJanuary2015);

            IsFalse(weeklyEvent.OccursOnDate(new DateTime(2015, 1, 1)), "Thursday 1st January");
            IsFalse(weeklyEvent.OccursOnDate(new DateTime(2015, 1, 3)), "Saturday 3rd January");
            IsFalse(weeklyEvent.OccursOnDate(new DateTime(2015, 1, 4)), "Sunday 3rd January");
            IsFalse(weeklyEvent.OccursOnDate(new DateTime(2015, 1, 6)), "Tuesday 3rd January");
            IsFalse(weeklyEvent.OccursOnDate(new DateTime(2015, 1, 7)), "Wednesday 3rd January");
        }

        [Test]
        public void weekly_repeating_event_when_day_matches_but_is_not_in_period()
        {
            var days = DaysOfWeek.Monday | DaysOfWeek.Friday;
            var weeklyEvent = new WeeklyRepeatingEvent(days, FirstOfJanuary2015, ThirtyFirstOfJanuary2015);

            IsFalse(weeklyEvent.OccursOnDate(new DateTime(2015, 2, 2)), "Monday 2nd February");
        }
    }
}
