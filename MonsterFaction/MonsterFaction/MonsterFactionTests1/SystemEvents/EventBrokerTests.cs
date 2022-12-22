using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterFaction.SystemEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterFaction.SystemEvents.Tests
{
    [TestClass()]
    public class EventTests
    {
        [TestMethod()]
        public void PublishEventTest()
        {
            var subsciber = new EventSubscriber<CreateEvent>(EventType.CREATE);
            var testEvent1 = new CreateEvent { ObjectId = 10 };
            var testEvent2 = new CreateEvent { ObjectId = 20 };
            EventBroker.PublishEvent(testEvent1);
            EventBroker.PublishEvent(testEvent2);
            Assert.IsTrue(
                subsciber.FetchAll().SequenceEqual(new List<CreateEvent>() { testEvent1, testEvent2 })
                );
            Assert.AreEqual(0, subsciber.FetchAll().Count());
        }

        [TestMethod()]
        public void MultiSubscriberTest()
        {
            var subsciber1 = new EventSubscriber<CreateEvent>(EventType.CREATE);
            var testEvent1 = new CreateEvent { ObjectId = 10 };
            EventBroker.PublishEvent(testEvent1);

            var testEvent2 = new CreateEvent { ObjectId = 20 };
            var subsciber2 = new EventSubscriber<CreateEvent>(EventType.CREATE);
            EventBroker.PublishEvent(testEvent2);

            Assert.IsTrue(
                subsciber1.FetchAll().SequenceEqual(new List<CreateEvent>() { testEvent1, testEvent2 })
                );
            Assert.IsTrue(
                subsciber2.FetchAll().SequenceEqual(new List<CreateEvent>() { testEvent2 })
                );
        }
    }
}