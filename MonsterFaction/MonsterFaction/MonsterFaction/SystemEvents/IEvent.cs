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
        public readonly Center Center { get; init; }
        public CreateEvent(int objectId, IShape shape, Center center)
        {
            EventType = EventType.OBJECT_CREATE;
            ObjectId = objectId;
            Shape = shape;
            Center = center;
        }
    }
    public readonly struct MoveEvent : IEvent
    {
        public readonly EventType EventType { get; init; }
        public readonly int ObjectId { get; init; }
        public readonly Center NewPosition { get; init; }
        public MoveEvent(int objectId, Center newPosition)
        {
            EventType = EventType.OBJECT_MOVE;
            ObjectId = objectId;
            NewPosition = newPosition;
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
