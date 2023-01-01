using System.Numerics;

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
            this.EventType = EventType.OBJECT_CREATE;
            this.ObjectId = ObjectId;
        }
    }
    public readonly struct MoveEvent : IEvent
    {
        public readonly EventType EventType { get; init; }
        public readonly int ObjectId { get; init; }
        public readonly Vector2 NewPosition { get; init; }
        public MoveEvent(int ObjectId, Vector2 newPosition)
        {
            this.EventType = EventType.OBJECT_MOVE;
            this.ObjectId = ObjectId;
            this.NewPosition = newPosition;
        }
    }

    public readonly struct DeleteEvent : IEvent
    {
        public readonly EventType EventType { get; init; }
        public readonly int ObjectId { get; init; }
        public DeleteEvent(int ObjectId)
        {
            this.EventType = EventType.OBJECT_DELETE;
            this.ObjectId = ObjectId;
        }
    }
}
