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
        public readonly Area Area { get; }
        public CreateEvent(int objectId, Area area)
        {
            EventType = EventType.OBJECT_CREATE;
            ObjectId = objectId;
            Area = area;
        }
    }
    public readonly struct DeleteEvent : IEvent
    {
        public readonly EventType EventType { get; }
        public readonly int ObjectId { get; }
        public DeleteEvent(int objectId)
        {
            EventType = EventType.OBJECT_DELETE;
            ObjectId = objectId;
        }
    }
    public readonly struct AttackEvent : IEvent
    {
        public readonly EventType EventType { get; }
        public readonly Area Area { get; }
        public readonly bool HumanTeam { get; }
        public AttackEvent(Area area, bool humanTeam)
        {
            EventType = EventType.ATTACK;
            Area = area;
            HumanTeam = humanTeam;
        }
    }
}
