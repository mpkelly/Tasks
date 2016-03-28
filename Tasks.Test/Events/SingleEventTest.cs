using System;
using NUnit.Framework;
using Tasks.Events;
using static NUnit.Framework.Assert;

namespace Tasks.Test.Events
{
    public class SingleEventTest : AbstractEventTest
    {
        [Test]
        public void occurs_on_date_when_input_datetime_matches()
        {
            var singleEvent = new SingleEvent(SevenAmOnBoxingDay2015);

            IsTrue(singleEvent.OccursOnDate(SevenAmOnBoxingDay2015));
        }

        [Test]
        public void occurs_on_date_when_input_datetime_does_not_match()
        {
            var singleEvent = new SingleEvent(SevenAmOnBoxingDay2015);

            IsFalse(singleEvent.OccursOnDate(DateTime.Now));
        }
    }
}