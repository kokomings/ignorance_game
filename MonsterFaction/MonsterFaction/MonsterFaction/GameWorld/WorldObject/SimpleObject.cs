using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;
using MonsterFaction.Util;

namespace MonsterFaction.GameWorld.WorldObject
{
    public class SimpleObject : IDrawable
    {
        public readonly int ID = IdGenerator.NextObjectId();

        public IShape Shape { get; }

        public Center Center { get; set; }
        public Direction Direction { get; set; }

        public SimpleObject(IShape shape, Center center)
        {
            Shape = shape;
            Center = center;
            Direction = new Direction(1, 0);
        }
    }
}
