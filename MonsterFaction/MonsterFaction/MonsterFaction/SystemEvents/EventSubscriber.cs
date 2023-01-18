using System.Collections.Generic;

namespace MonsterFaction.SystemEvents
{
    // Event 발행 전에 구독을 해놔야함.
    public class EventSubscriber<T> where T : IEvent
    {
        private Queue<IEvent> eventQueue = new Queue<IEvent>();

        public EventSubscriber(EventType eventType)
        {
            EventBroker.Subscribe(eventType, eventQueue);
        }

        public List<T> FetchAll()
        {
            List<T> list = new List<T>();
            while (eventQueue.Count > 0)
            {
                list.Add((T)eventQueue.Dequeue());
            }
            return list;
        }
    }

}
