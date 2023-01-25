using MonsterFaction.Characters;
using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject.DomainObject
{
    public class HumanObject: SimpleObject
    {
        public Human Human { get; }
        public HumanObject(Human human, IShape shape, Center center) : base(shape, center)
        {
            Human = human;
        }

        public Area AttackArea()
        {
            Center attackCenter = this.Center + new Center(this.Direction.X * 100, this.Direction.Y * 100);
            return new Area(new CircleShape(20), attackCenter);
        }
    }
}
