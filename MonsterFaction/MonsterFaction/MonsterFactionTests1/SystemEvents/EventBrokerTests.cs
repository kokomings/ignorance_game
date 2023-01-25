using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonsterFaction.SystemEvents.Tests
{
    class TestEvent: IEvent
    {
        public int Id { get; set; }
        EventType IEvent.EventType => EventType.OBJECT_CREATE; // 테스트 용

        public TestEvent(int id)
        {
            Id = id;
        }
    }

    [TestClass()]
    public class EventTests
    {
        [TestMethod()]
        public void PublishEventTest()
        {
            var subsciber = new EventSubscriber<TestEvent>(EventType.OBJECT_CREATE);
            var testEvent1 = new TestEvent(10);
            var testEvent2 = new TestEvent(20);
            EventBroker.PublishEvent(testEvent1);
            EventBroker.PublishEvent(testEvent2);
            Assert.IsTrue(
                subsciber.FetchAll().SequenceEqual(new List<TestEvent>() { testEvent1, testEvent2 })
                );
            Assert.AreEqual(0, subsciber.FetchAll().Count());
        }

        [TestMethod()]
        public void MultiSubscriberTest()
        {
            var subsciber1 = new EventSubscriber<TestEvent>(EventType.OBJECT_CREATE);
            var testEvent1 = new TestEvent(10);
            EventBroker.PublishEvent(testEvent1);

            var testEvent2 = new TestEvent(20);
            var subsciber2 = new EventSubscriber<TestEvent>(EventType.OBJECT_CREATE);
            EventBroker.PublishEvent(testEvent2);

            Assert.IsTrue(
                subsciber1.FetchAll().SequenceEqual(new List<TestEvent>() { testEvent1, testEvent2 })
                );
            Assert.IsTrue(
                subsciber2.FetchAll().SequenceEqual(new List<TestEvent>() { testEvent2 })
                );
        }
    }
}