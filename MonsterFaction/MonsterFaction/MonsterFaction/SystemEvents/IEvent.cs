namespace MonsterFaction.SystemEvents
{
    public interface IEvent 
    {
        public EventType EventType { get; init; }
    }

    public readonly struct CreateEvent : IEvent
    {
        public readonly EventType EventType { get; init; }
        public readonly int ObjectId { get; init; }
        public CreateEvent(int ObjectId)
        {
            this.EventType = EventType.CREATE;
            this.ObjectId = ObjectId;
        }
    }

    public readonly struct DeleteEvent : IEvent
    {
        public readonly EventType EventType { get; init; }
        public readonly int ObjectId { get; init; }
        public DeleteEvent(int ObjectId)
        {
            this.EventType = EventType.DELETE;
            this.ObjectId = ObjectId;
        }
    }
}
