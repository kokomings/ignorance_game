using MonsterFaction.GameWorld.WorldObject.Shape;

namespace MonsterFaction.GameWorld.WorldObject
{
    public interface IDrawable
    {
        public IShape Shape { get; }
        public IMovement Movement { get; }
    }
}
