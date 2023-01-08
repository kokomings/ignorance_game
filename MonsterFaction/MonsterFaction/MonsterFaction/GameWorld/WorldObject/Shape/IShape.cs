using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject.Shape
{
    public interface IShape
    {
        public Size Size { get; }
        public Center Center { get; }
    }
}
