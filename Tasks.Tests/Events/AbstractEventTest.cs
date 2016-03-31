using System;
using NUnit.Framework;

namespace Tasks.Test.Events
{
    [TestFixture(Category = TestCategories.Unit)]
    public abstract class AbstractEventTest
    {
        protected readonly DateTime FirstOfJanuary2015 = new DateTime(2015, 1, 1);
        protected readonly DateTime ThirtyFirstOfJanuary2015 = new DateTime(2015, 1, 31);
        protected readonly DateTime SevenAmOnBoxingDay2015 = new DateTime(2015, 12, 26, 7, 0, 0);
        protected readonly DateTime ThirtyFirstOfDecember2015 = new DateTime(2015, 12, 31);
    }
}
