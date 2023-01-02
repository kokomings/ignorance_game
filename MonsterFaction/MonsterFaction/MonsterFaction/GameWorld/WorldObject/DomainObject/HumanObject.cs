using MonsterFaction.Characters;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject.DomainObject
{
    public class HumanObject: SimpleObject
    {
        public Human Human { get; }
        public HumanObject(Human human, IShape shape) : base(shape)
        {
            Human = human;
        }
    }
}
