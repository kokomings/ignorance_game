using System.Collections.Generic;
using System.ComponentModel.Design;

namespace MonsterFaction.SystemEvents
{
    public class EventBroker
    {
        private static readonly Dictionary<EventType, List<Queue<IEvent>>> eventChannels = new(); 

        public static void PublishEvent(IEvent systemEvent)
        {
            initialize(systemEvent.EventType);
            var channel = eventChannels[systemEvent.EventType];
            foreach(var eventQueue in channel)
            {
                eventQueue.Enqueue(systemEvent);
            }
        }

        public static void Subscribe(EventType eventType, Queue<IEvent> eventQueue)
        {
            initialize(eventType);
            eventChannels[eventType].Add(eventQueue);
        }

        private static void initialize(EventType eventType)
        {
            if (!eventChannels.ContainsKey(eventType))
            {
                eventChannels[eventType] = new();
            }
        }
    }
}
