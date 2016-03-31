using System;
using NUnit.Framework;
using Tasks.Events;
using static NUnit.Framework.Assert;
using static Tasks.Events.NDaysRepeatingEvent;

namespace Tasks.Test.Events
{
    public class NDaysRepeatingEventTest : AbstractEventTest
    {
        [Test]
        public void daily_repeating_event_when_input_date_matches()
        {
            var dailyRepeatingEvent = DailyRepeatingEvent(FirstOfJanuary2015, ThirtyFirstOfDecember2015);

            IsTrue(dailyRepeatingEvent.OccursOnDate(SevenAmOnBoxingDay2015));
        }

        [Test]
        public void daily_repeating_event_when_date_does_not_match()
        {
            var dailyRepeatingEvent = DailyRepeatingEvent(FirstOfJanuary2015, SevenAmOnBoxingDay2015);

            IsFalse(dailyRepeatingEvent.OccursOnDate(ThirtyFirstOfDecember2015));
        }

        [Test]
        public void ten_days_repeating_event_when_dates_match()
        {
            var dailyRepeatingEvent = new NDaysRepeatingEvent(10, FirstOfJanuary2015, ThirtyFirstOfDecember2015);

            IsTrue(dailyRepeatingEvent.OccursOnDate(new DateTime(2015, 1, 11)), "11th Jan");
            IsTrue(dailyRepeatingEvent.OccursOnDate(new DateTime(2015, 1, 21)), "21st Jan");
            IsTrue(dailyRepeatingEvent.OccursOnDate(new DateTime(2015, 1, 31)), "31st Jan");
            IsTrue(dailyRepeatingEvent.OccursOnDate(new DateTime(2015, 2, 10)), "10th February");
        }
    }
}