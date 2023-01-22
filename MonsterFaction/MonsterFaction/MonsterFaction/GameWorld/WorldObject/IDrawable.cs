using MonsterFaction.GameWorld.WorldObject.Shape;
using MonsterFaction.GameWorld.WorldObject.VectorUnit;

namespace MonsterFaction.GameWorld.WorldObject
{
    public interface IDrawable
    {
        public IShape Shape { get; }
        public Center Center { get; }
    }
}
