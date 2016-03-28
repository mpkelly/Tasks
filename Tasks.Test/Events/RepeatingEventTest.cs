using NUnit.Framework;
using static NUnit.Framework.Assert;
using static Tasks.Events.RepeatingEvent;

namespace Tasks.Test.Events
{
    public class RepeatingEventTest : AbstractEventTest
    {
        [Test]
        public void daily_repeating_event_occurs_on_date_when_input_datetime_matches()
        {
            var dailyRepeatingEvent = DailyRepeatingEvent(FirstOfJanuary2015, ThirtyFirstOfDecember2015);

            IsTrue(dailyRepeatingEvent.OccursOnDate(SevenAmOnBoxingDay2015));
        }

        [Test]
        public void daily_repeating_event_occurs_on_date_when_input_datetime_does_not_match()
        {
            var dailyRepeatingEvent = DailyRepeatingEvent(FirstOfJanuary2015, SevenAmOnBoxingDay2015);

            IsFalse(dailyRepeatingEvent.OccursOnDate(ThirtyFirstOfDecember2015));
        }

        [Test]
        public void weekly_repeating_event_occurs_on_date_when_input_date_time_matches()
        {
            var dailyRepeatingEvent = DailyRepeatingEvent(FirstOfJanuary2015, ThirtyFirstOfDecember2015);

            IsTrue(dailyRepeatingEvent.OccursOnDate(SevenAmOnBoxingDay2015));
        }
    }
}