using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.GameWorld.WorldObject.Shape;

namespace MonsterFaction.SystemEvents
{
    public interface IEvent 
    {
        public EventType EventType { get; }
    }

    public readonly struct CreateEvent : IEvent
    {
        public readonly EventType EventType { get; }
        public readonly int ObjectId { get; }
        public readonly IShape Shape { get; }
        public readonly Center Center { get; }
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
        public readonly EventType EventType { get; }
        public readonly int ObjectId { get; }
        public readonly Center NewPosition { get; }
        public MoveEvent(int objectId, Center newPosition)
        {
            EventType = EventType.OBJECT_MOVE;
            ObjectId = objectId;
            NewPosition = newPosition;
        }
    }

    public readonly struct DeleteEvent : IEvent
    {
        public readonly EventType EventType { get; }
        public readonly int ObjectId { get; }
        public DeleteEvent(int ObjectId)
        {
            this.EventType = EventType.OBJECT_DELETE;
            this.ObjectId = ObjectId;
        }
    }
    public readonly struct AttackEvent : IEvent
    {
        public readonly EventType EventType { get; }
        public readonly IShape Shape { get; }
        public readonly Center Center { get; }
        public readonly bool HumanTeam { get; }
        public AttackEvent(IShape shape, Center center, bool humanTeam)
        {
            this.EventType = EventType.ATTACK;
            this.Shape = shape;
            this.Center = center;
            this.HumanTeam = humanTeam;
        }
    }
}
