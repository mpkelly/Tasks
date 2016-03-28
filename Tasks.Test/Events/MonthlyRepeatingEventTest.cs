using System;
using NUnit.Framework;
using Tasks.Events;
using static NUnit.Framework.Assert;

namespace Tasks.Test.Events
{
    public class MonthlyRepeatingEventTest : AbstractEventTest
    {
        [Test]
        public void monthly_repeating_event_when_day_matches()
        {
            var monthlyEvent = new MonthlyRepeatingEvent(31, FirstOfJanuary2015, ThirtyFirstOfJanuary2015);

            IsTrue(monthlyEvent.OccursOnDate(ThirtyFirstOfJanuary2015));
        }

        [Test]
        public void monthly_repeating_event_when_day_greater_than_last_day_of_month()
        {
            var monthlyEvent = new MonthlyRepeatingEvent(31, FirstOfJanuary2015, ThirtyFirstOfDecember2015);

            IsTrue(monthlyEvent.OccursOnDate(new DateTime(2015, 2, 28)), "28th February 2015");
        }

        [Test]
        public void monthly_repeating_event_when_day_matches_but_not_in_period()
        {
            var monthlyEvent = new MonthlyRepeatingEvent(31, FirstOfJanuary2015, ThirtyFirstOfJanuary2015);

            IsFalse(monthlyEvent.OccursOnDate(new DateTime(2015, 3, 31)), "31st March 2015");
        }
    }
}