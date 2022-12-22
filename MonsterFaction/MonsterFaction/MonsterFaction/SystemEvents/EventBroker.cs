using System.Collections.Generic;

namespace MonsterFaction.SystemEvents
{
    public class EventBroker
    {
        private static readonly Dictionary<EventType, List<Queue<IEvent>>> eventChannels = new(); 

        public static void PublishEvent(IEvent systemEvent)
        {
            var channel = eventChannels[systemEvent.EventType];
            foreach(var eventQueue in channel)
            {
                eventQueue.Enqueue(systemEvent);
            }
        }

        public static void Subscribe(EventType eventType, Queue<IEvent> eventQueue)
        {
            if (!eventChannels.ContainsKey(eventType))
            {
                eventChannels[eventType] = new();
            }
            eventChannels[eventType].Add(eventQueue);
        }
    }
}
