using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.GameWorld.WorldObject.Shape;

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
        public readonly IShape Shape { get; init; }
        public CreateEvent(int ObjectId, IShape shape)
        {
            this.EventType = EventType.OBJECT_CREATE;
            this.ObjectId = ObjectId;
            this.Shape = shape;
        }
    }
    public readonly struct MoveEvent : IEvent
    {
        public readonly EventType EventType { get; init; }
        public readonly int ObjectId { get; init; }
        public readonly Center NewPosition { get; init; }
        public MoveEvent(int ObjectId, Center newPosition)
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
